using Application.Dto.Message;
using Application.Dto.User;
using Application.IContracts.IRepository;
using Domain.Entities.ChatEntity;
using Domain.Entities.IdentityEntity;
using Domain.Entities.MessageEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebApi.Extensions;

namespace WebApi.SignalR;

public class ChatHub : Hub<IClient>
{
    #region Properties

    private string GroupName;
    private User UserAsker;
    private User UserResponder;
    private Connection Connection;
    private string ConnectionId;
    private Group Group;

    #endregion

    #region CtorAndInjection

    private readonly IChatRepository _chatRepository;
    private readonly UserManager<User> _userManager;
    private readonly PresenceTracker _presenceTracker;
    private readonly IHubContext<PresenceHub> _presenceHub;
    private readonly IMessageRepository _messageRepository;
    private readonly ChatTracker _chatTracker;

    public ChatHub(IChatRepository chatRepository, UserManager<User> userManager, PresenceTracker presenceTracker,
        IHubContext<PresenceHub> presenceHub, IMessageRepository messageRepository, ChatTracker chatTracker)
    {
        _chatRepository = chatRepository;
        _userManager = userManager;
        _presenceTracker = presenceTracker;
        _presenceHub = presenceHub;
        _messageRepository = messageRepository;
        _chatTracker = chatTracker;
    }

    #endregion

    #region Connected
    public override async Task OnConnectedAsync()
    {
        await _chatTracker.UserConnected(Context.User.GetPhoneNumber(), Context.ConnectionId);
    }
    #endregion

    #region Disconnected

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await _chatRepository.ConnectionDeleteInGroup(Context.ConnectionId);
        await _presenceTracker.UserDisconnected(Context.User.GetPhoneNumber(), Context.ConnectionId);
        await base.OnDisconnectedAsync(exception);
    }

    #endregion

    #region CreateGroup

    public async Task<List<MessageDto>> CreateGroup(string userResponderPhoneNumber)
    {
        UserAsker = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == Context.User.GetPhoneNumber());
        UserResponder = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == userResponderPhoneNumber);
        ConnectionId = Context.ConnectionId;

        GroupName = CreateGroupName(UserAsker?.PhoneNumber, UserResponder?.PhoneNumber);
        await Groups.AddToGroupAsync(ConnectionId, GroupName);
        await CreateGroupTool(UserResponder.Id, UserAsker.Id);
        await CreateConnectionTool();
        await Clients.Caller.SetGroupName(GroupName);
        
        var messages = await _messageRepository.MessageGetBetween(
            UserAsker.PhoneNumber, UserResponder.PhoneNumber);
        
        var responderConnectionsChat =await _chatTracker.GetOnlineUserInChatEntire(UserResponder.PhoneNumber);
        var responderInGroup = await _chatRepository.UserInGroup(GroupName, responderConnectionsChat);
        if (responderInGroup)
        {
            await Clients.Clients(responderConnectionsChat).UpdateMessages(messages);
        }
        return messages;
    }

    #endregion

    #region UserInGroupsGet

    public async Task<List<UserDto>> UserInGroupsGet(string askerPhoneNumber)
    {
        var users = await _chatRepository.UserInGroupsGet(askerPhoneNumber);
        return users;
    }

    #endregion

    #region ConnectionDeleteInGroup

    public async Task ConnectionDeleteInGroup()
    {
        await _chatRepository.ConnectionDeleteInGroup(Context.ConnectionId);
    }

    #endregion

    #region MessageAdd

    public async Task MessageAdd(MessageAddDto messageAddDto)
    {
        UserAsker = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == Context.User.GetPhoneNumber());
        UserResponder =
            await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == messageAddDto.ResponderPhoneNumber);
        ConnectionId = Context.ConnectionId;
        GroupName = CreateGroupName(UserAsker.PhoneNumber, UserResponder.PhoneNumber);

        messageAddDto.AskerPhoneNumber = UserAsker?.PhoneNumber;
        messageAddDto.AskerId = UserAsker?.Id;
        messageAddDto.ResponderId = UserResponder?.Id;

        var messageDto = await _messageRepository.MessageAdd(messageAddDto);
        if (messageDto == null) throw new Exception("error Create message");
        var responderConnectionsChat =await _chatTracker.GetOnlineUserInChatEntire(UserResponder.PhoneNumber);
        var responderInGroup = await _chatRepository.UserInGroup(GroupName, responderConnectionsChat);
        if (responderInGroup)
        {
            await TurnToRead(messageDto);
        }
        else if(responderConnectionsChat != null && responderConnectionsChat.Count>0)
        {
           var messages=await _messageRepository.MessageGetBetween(UserAsker.PhoneNumber, UserResponder.PhoneNumber);
            if (messages.Count == 1) await Clients.Clients(responderConnectionsChat).ShowNewGroup();
        }
        await Clients.Group(GroupName).ShowNewMessage(messageDto);  
        if (!responderInGroup)
        {
            var userResponderConnections = await _presenceTracker.GetOnlineUserEntire(UserResponder.PhoneNumber);
            if (userResponderConnections != null)
                await _presenceHub.Clients.Clients(userResponderConnections).SendAsync("HaveNewMessage");
        }
    }
    #endregion

    #region Tools
    private async Task TurnToRead(MessageDto messageDto)
    {
        var message = new Message(messageDto.AskerPhoneNumber, messageDto.ResponderPhoneNumber, messageDto.Content,
            messageDto.PictureUrl, messageDto.AskerId, messageDto.ResponderId);
        await _messageRepository.TurnMessagesToRead(new List<Message>() { message }, UserAsker.PhoneNumber);
        messageDto.IsRead = true;
    }
    private async Task CreateConnectionTool()
    {
        var connectionExist = await _chatRepository.ConnectionExistAsync(ConnectionId);
        switch (connectionExist)
        {
            case true:
                return;
            case false:
                Connection = new Connection(ConnectionId, UserAsker.PhoneNumber, UserAsker.Id, Group.Id);
                await _chatRepository.ConnectionAddAsync(Connection);
                break;
        }
    }

    private async Task CreateGroupTool(string userResponderId, string userAskerId)
    {
        var groupExist = await _chatRepository.GroupExistAsync(GroupName);
        switch (groupExist)
        {
            case true:
                Group = await _chatRepository.GroupGetAsync(GroupName);
                await CreateConnectionTool();
                return;
            case false:
                Group = new Group(GroupName, userResponderId, userAskerId);
                await _chatRepository.GroupAddAsync(Group);
                await CreateConnectionTool();
                break;
        }
    }

    private static string? CreateGroupName(string userAskerPhoneNumber, string userResponderPhoneNumber)
    {
        var compare = string.CompareOrdinal(userAskerPhoneNumber, userResponderPhoneNumber) < 0;
        return compare
            ? $"{userAskerPhoneNumber}-{userResponderPhoneNumber}"
            : $"{userResponderPhoneNumber}-{userAskerPhoneNumber}";
    }

    #endregion
}