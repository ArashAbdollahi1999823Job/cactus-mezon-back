using Application.Common.Helpers;
using Application.Dto.Chat.Group;
using Application.Enums;
using Application.IContracts.IServices;
using Domain.Entities.ChatEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebApi.Contracts.IApplication;
using WebApi.Contracts.IRepository;
using WebApi.SignalR;
namespace WebApi.Contracts.Application;
public class GroupApplication:IGroupApplication
{
    #region CtorAndInjection
    private readonly IGroupRepository _groupRepository;
    private readonly UserManager<Domain.Entities.IdentityEntity.User> _userManager;
    private readonly ICurrentUserService _currentUserService;
    private readonly IConnectionRepository _connectionRepository;
    private readonly IHubContext<ChatHub> _chatHub;
    private readonly ChatTracker _chatTracker;
    private readonly IMessageRepository _messageRepository;
    private readonly PresenceTracker _presenceTracker;
    public GroupApplication(IGroupRepository groupRepository, UserManager<Domain.Entities.IdentityEntity.User> userManager, ICurrentUserService currentUserService, IConnectionRepository connectionRepository, IHubContext<ChatHub> chatHub, ChatTracker chatTracker, IMessageRepository messageRepository, PresenceTracker presenceTracker)
    {
        _groupRepository = groupRepository;
        _userManager = userManager;
        _currentUserService = currentUserService;
        _connectionRepository = connectionRepository;
        _chatHub = chatHub;
        _chatTracker = chatTracker;
        _messageRepository = messageRepository;
        _presenceTracker = presenceTracker;
    }
    #endregion

    #region GroupAddAsync
    public async Task<GroupDto> GroupAddAsync(GroupAddDto groupAddDto)
    {
        GroupDto groupDto ;
        var userResponder =await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == groupAddDto.ResponderPhoneNumber);
        var userAsker =await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber ==_currentUserService.PhoneNumber);
        var connectionId =  _chatTracker.GetConnectionsOnlineUserInChat(userAsker.PhoneNumber).Result.LastOrDefault();
        var groupName = Tools.CreateGroupName(userAsker.PhoneNumber, userResponder.PhoneNumber);
        var groupExist = await _groupRepository.GroupExistAsync(groupName);
        await _connectionRepository.ConnectionDeleteAsync(connectionId);
        switch (groupExist)
        {
            case true:
                groupDto =_groupRepository.GroupGetAllAsync(new GroupSearchDto(groupName,HasMessageType.NotImportant)).Result[0];
                await _connectionRepository.ConnectionAddAsync(new Connection(connectionId, userAsker.PhoneNumber, userAsker.Id, groupDto.Id));
                break;
            case false:
                await _groupRepository.GroupAddAsync(new GroupAddDto(groupName,userResponder.Id,userAsker.Id));
                groupDto =_groupRepository.GroupGetAllAsync(new GroupSearchDto(groupName,HasMessageType.NotImportant)).Result[0];
                await _connectionRepository.ConnectionAddAsync(new Connection(connectionId, userAsker.PhoneNumber, userAsker.Id, groupDto.Id));
                break;
        }
        await _chatHub.Groups.AddToGroupAsync(connectionId, groupName);
        return groupDto;
    }
    #endregion

    #region GroupGetAllAsync
    public async Task<List<GroupDto>> GroupGetAllAsync(GroupSearchDto groupSearchDto)
    {
      return  await _groupRepository.GroupGetAllAsync(groupSearchDto);
    }
    #endregion
}