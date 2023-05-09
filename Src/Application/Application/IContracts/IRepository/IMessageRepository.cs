using Application.Dto.Message;
using Domain.Entities.MessageEntity;


namespace Application.IContracts.IRepository;

public interface IMessageRepository
{
    public Task<MessageDto> MessageAdd(MessageAddDto  messageAddDto);
    public Task<List<MessageDto>> MessageGetBetween(string askerPhoneNumber, string responderPhoneNumber);

    public Task TurnMessagesToRead(List<Message> messages,string askerPhoneNumber);
}