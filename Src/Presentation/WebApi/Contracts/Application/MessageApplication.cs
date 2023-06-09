using Application.Dto.Base;
using Application.Dto.Chat.Group;
using Application.Dto.Chat.Message;
using Application.Enums;
using Application.IContracts.IRepository;
using Application.IContracts.IServices;
using Domain.Entities.IdentityEntity;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApi.Contracts.IApplication;
using WebApi.Contracts.IRepository;
using WebApi.SignalR;
namespace WebApi.Contracts.Application;

public class MessageApplication : IMessageApplication
{
    #region CtorAndInjection

    private readonly IMessageRepository _messageRepository;
    private readonly IFileUploader _fileUploader;
    private readonly ICurrentUserService _currentUserService;
    private readonly UserManager<User> _userManager;
    private readonly IGroupRepository _groupRepository;
    private readonly ChatTracker _chatTracker;
    private readonly PresenceTracker _presenceTracker;
    private readonly IConnectionRepository _connectionRepository;
    private readonly ApplicationDbContext _context;

    public MessageApplication(IMessageRepository messageRepository, IFileUploader fileUploader,
        ICurrentUserService currentUserService, UserManager<User> userManager, IGroupRepository groupRepository,
        ChatTracker chatTracker, PresenceTracker presenceTracker, IConnectionRepository connectionRepository,
        ApplicationDbContext context)
    {
        _messageRepository = messageRepository;
        _fileUploader = fileUploader;
        _currentUserService = currentUserService;
        _userManager = userManager;
        _groupRepository = groupRepository;
        _chatTracker = chatTracker;
        _presenceTracker = presenceTracker;
        _connectionRepository = connectionRepository;
        _context = context;
    }

    #endregion

    #region MessageAddAsync

    public async Task<MessageDto> MessageAddAsync(MessageAddDto messageAddDto)
    {
        var userResponder =
            await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == messageAddDto.ResponderPhoneNumber);
        var groupDto = _groupRepository
            .GroupGetAllAsync(new GroupSearchDto(messageAddDto.GroupName, HasMessageType.NotImportant)).Result[0];
        messageAddDto.ResponderId = userResponder.Id;
        messageAddDto.GroupId = groupDto.Id;
        messageAddDto.AskerId = _currentUserService.Id;
        messageAddDto.AskerPhoneNumber = _currentUserService.PhoneNumber;
        if (messageAddDto.Picture != null)
        {
            var path = $"Picture/group/{messageAddDto.GroupName}/{messageAddDto.AskerPhoneNumber}";
            messageAddDto.PictureUrl = _fileUploader.Upload(messageAddDto.Picture, path);
        }
        var messageDto = await _messageRepository.MessageAddAsync(messageAddDto);
        await GroupUpdateAsync(userResponder.PhoneNumber);
        await MessageUpdateAsync(_currentUserService.PhoneNumber, groupDto.Name);
        await MessageUpdateAsync(userResponder.PhoneNumber, groupDto.Name);
        return messageDto;
    }

    #endregion

    #region GroupUpdateAsync

    public async Task GroupUpdateAsync(string userPhoneNumber)
    {
        var userChatConnections = await _chatTracker.GetConnectionsOnlineUserInChat(userPhoneNumber);
        if (userChatConnections?.Count > 0 && userChatConnections != null)
        {
            await _messageRepository.GroupUpdateAsync(userChatConnections);
        }
    }

    #endregion

    #region MessageGetAllAsync
    public async Task<PaginationDto<MessageDto>> MessageGetAllAsync(MessageSearchDto messageSearchDto)
    {
        var messageDto = await _messageRepository.MessageGetAllAsync(messageSearchDto);
        var count = messageDto.Data
            .Where(x => x.IsRead == false && x.ResponderPhoneNumber == _currentUserService.PhoneNumber).ToList().Count;
        if (count > 0)
        {
            var message = await _context.Messages.Where(x => x.IsRead == false && x.ResponderPhoneNumber == _currentUserService.PhoneNumber && x.GroupName == messageSearchDto.GroupName).ToListAsync();
         
            await _messageRepository.TurnMessagesToRead(message, _currentUserService.PhoneNumber);
           
            var otherUserPhoneNumber = messageDto.Data.FirstOrDefault(x => x.AskerPhoneNumber != _currentUserService.PhoneNumber)?.AskerPhoneNumber;
          
            var userResponderChatConnection = await _chatTracker.GetConnectionsOnlineUserInChat(otherUserPhoneNumber);
          
            if (userResponderChatConnection?.Count > 0)
                await _messageRepository.ChatMessageUpdateAsync(userResponderChatConnection);
            
            var userAskerPresenceConnection = await _presenceTracker.GetOnlineUserEntire(_currentUserService.PhoneNumber);
            if (userAskerPresenceConnection?.Count > 0)
                await _messageRepository.MessageUnReadUpdateAsync(userAskerPresenceConnection);
        }

        return await _messageRepository.MessageGetAllAsync(messageSearchDto);
    }

    #endregion
    
    #region MessageGetAllJustAsync
    public async Task<PaginationDto<MessageDto>> MessageGetAllJustAsync(MessageSearchDto messageSearchDto)
    {
        return await _messageRepository.MessageGetAllAsync(messageSearchDto);
    }
    #endregion

    #region MessageUpdateAsync
    public async Task MessageUpdateAsync(string userPhoneNumber, string groupName)
    {
        var userChatConnections = await _chatTracker.GetConnectionsOnlineUserInChat(userPhoneNumber);
        var userPresenceConnections = await _presenceTracker.GetOnlineUserEntire(userPhoneNumber);
        if (userChatConnections?.Count > 0 && userChatConnections != null)
        {
            var checkUserInGroup = await _connectionRepository.UserInGroup(groupName, userChatConnections);
            if (checkUserInGroup)
            {
                await _messageRepository.ChatMessageUpdateAsync(userChatConnections);
            }
            else
            {
                if (userPresenceConnections?.Count > 0 && userPresenceConnections != null)
                {
                    await _messageRepository.MessageUnReadUpdateAsync(userPresenceConnections);
                }
            }
        }
        else if (userPresenceConnections?.Count > 0 && userPresenceConnections != null)
        {
            await _messageRepository.MessageUnReadUpdateAsync(userPresenceConnections);
        }
    }

    #endregion
}