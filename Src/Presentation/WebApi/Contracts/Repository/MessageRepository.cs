using Application.Common.Messages;
using Application.Dto.Base;
using Application.Dto.Chat.Message;
using Application.Enums;
using AutoMapper;
using Domain.Entities.ChatEntity;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebApi.Contracts.IRepository;
using WebApi.SignalR;
namespace WebApi.Contracts.Repository;
public class MessageRepository : IMessageRepository
{
    #region CtorAndInjection

    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IHubContext<ChatHub> _chatHub;
    private readonly IHubContext<PresenceHub> _presenceHub;

    public MessageRepository(ApplicationDbContext context, IMapper mapper, IHubContext<ChatHub> chatHub,
        IHubContext<PresenceHub> presenceHub)
    {
        _context = context;
        _mapper = mapper;
        _chatHub = chatHub;
        _presenceHub = presenceHub;
    }

    #endregion

    #region MessageAddAsync
    public async Task<MessageDto> MessageAddAsync(MessageAddDto messageAddDto)
    {
        var message = new Message(messageAddDto.AskerPhoneNumber, messageAddDto.ResponderPhoneNumber,
            messageAddDto.Content, messageAddDto.PictureUrl, messageAddDto.AskerId, messageAddDto.ResponderId,
            messageAddDto.GroupId, messageAddDto.GroupName);

        await _context.Messages.AddAsync(message);
        var check = await _context.SaveChangesAsync();
        if (check > 0)
        {
            return _mapper.Map<Message, MessageDto>(message);
        }

        throw new BadRequestEntityException(ApplicationMessages.MessageAddFailed);
    }
    #endregion

    #region MessageGetAllAsync

    public async Task<PaginationDto<MessageDto>> MessageGetAllAsync(MessageSearchDto messageSearchDto)
    {
        var query = _context.Messages.AsQueryable();
        if (!String.IsNullOrEmpty(messageSearchDto.GroupName))
            query = query.Where(x => x.GroupName.Contains(messageSearchDto.GroupName));
        if (!String.IsNullOrEmpty(messageSearchDto.AskerPhoneNumber))
            query = query.Where(x => x.AskerPhoneNumber == messageSearchDto.AskerPhoneNumber);
        if (!String.IsNullOrEmpty(messageSearchDto.ResponderPhoneNumber))
            query = query.Where(x => x.ResponderPhoneNumber == messageSearchDto.ResponderPhoneNumber);
        if (!String.IsNullOrEmpty(messageSearchDto.ResponderPhoneNumber))
            query = query.Where(x => x.ResponderPhoneNumber == messageSearchDto.ResponderPhoneNumber);
        if (messageSearchDto.IsRead != 0)
        {
            if (messageSearchDto.IsRead == IsReadType.Read) query = query.Where(x => x.IsRead == true);
            if (messageSearchDto.IsRead == IsReadType.UnRead) query = query.Where(x => x.IsRead == false);
        }

        if (messageSearchDto.Id.ToString() != "00000000-0000-0000-0000-000000000000")
            query = query.Where(x => x.Id == messageSearchDto.Id);
        query = query.OrderBy(x => x.CreationDate);
        var count = await query.CountAsync();
        var result = await query.Skip((messageSearchDto.PageIndex - 1) * messageSearchDto.PageSize)
            .Take(messageSearchDto.PageSize).ToListAsync();
        var data = _mapper.Map<List<MessageDto>>(result);
        return new PaginationDto<MessageDto>(messageSearchDto.PageIndex, messageSearchDto.PageSize, count, data);
    }

    #endregion

    #region ChatMessageUpdateAsync
    public async Task ChatMessageUpdateAsync(List<string> userConnections)
    {
        await _chatHub.Clients.Clients(userConnections).SendAsync("ChatMessageUpdate");
    }

    #endregion
    
    #region groupUpdateAsync

    public async Task GroupUpdateAsync(List<string> userConnections)
    {
        await _chatHub.Clients.Clients(userConnections).SendAsync("GroupUpdate");
    }

    #endregion
    
    #region MessageUnReadUpdateAsync
    public async Task MessageUnReadUpdateAsync(List<string> userConnections)
    {
        await _presenceHub.Clients.Clients(userConnections).SendAsync("MessageUnReadUpdate");
    }
    #endregion

    #region TurnMessageToReadAsync

    public async Task TurnMessagesToRead(List<Message> messages, string askerPhoneNumber)
    {
        var messagesMe = messages.Where(x => x.IsRead == false && x.ResponderPhoneNumber == askerPhoneNumber)
            .ToList();
        if (messagesMe.Any())
        {
            messagesMe.ForEach(x => { x.IsRead = true; });
            _context.Messages.UpdateRange(messages);
            await _context.SaveChangesAsync();
        }
    }

    #endregion
}