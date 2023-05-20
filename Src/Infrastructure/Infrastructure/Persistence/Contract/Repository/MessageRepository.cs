using Application.Common.Messages;
using Application.IContracts.IRepository;
using AutoMapper;
using Domain.Entities.ChatEntity;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contract.Repository;

public class MessageRepository : IMessageRepository
{
    /*#region CtorAndInjection

    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public MessageRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    #endregion

    public async Task<MessageDto> MessageAdd(MessageAddDto messageAddDto)
    {
        var message = new Message(messageAddDto.AskerPhoneNumber, messageAddDto.ResponderPhoneNumber,
            messageAddDto.Content, messageAddDto.PictureUrl, messageAddDto.AskerId, messageAddDto.ResponderId);
        await _context.Messages.AddAsync(message);
        var check = await _context.SaveChangesAsync();
        if (check <= 0) throw new BadRequestEntityException(ApplicationMessages.InventoryAddFailed);
        return _mapper.Map<Message, MessageDto>(await _context.Messages.Where(x=>x==message).FirstOrDefaultAsync());

    }

    public async Task<List<MessageDto>> MessageGetBetween(string askerPhoneNumber, string responderPhoneNumber)
    {
        var query = await _context.Messages.Where(x =>
                x.AskerPhoneNumber == askerPhoneNumber && x.ResponderPhoneNumber == responderPhoneNumber ||
                x.AskerPhoneNumber == responderPhoneNumber && x.ResponderPhoneNumber == askerPhoneNumber)
            .OrderBy(x => x.CreationDate)
            .ToListAsync();
        await TurnMessagesToRead(query, askerPhoneNumber);
        return _mapper.Map<List<Message>, List<MessageDto>>(query);
    }

   */
}