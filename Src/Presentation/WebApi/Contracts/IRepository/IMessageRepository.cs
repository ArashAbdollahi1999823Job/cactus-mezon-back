using Application.Dto.Base;
using Application.Dto.Chat.Message;
using Domain.Entities.ChatEntity;
namespace WebApi.Contracts.IRepository;
public interface IMessageRepository
{
    public Task<MessageDto> MessageAddAsync(MessageAddDto messageAddDto);
    public Task<PaginationDto<MessageDto>> MessageGetAllAsync(MessageSearchDto messageSearchDto);
    public Task ChatMessageUpdateAsync(List<string> userConnections);
    public Task PresenceMessageUpdateAsync(List<string> userConnections);
    public Task TurnMessagesToRead(List<Message> messages, string askerPhoneNumber);
    public Task GroupUpdateAsync(List<string> userConnections);
    public Task MessageUnReadUpdateAsync(List<string> userConnections);
}