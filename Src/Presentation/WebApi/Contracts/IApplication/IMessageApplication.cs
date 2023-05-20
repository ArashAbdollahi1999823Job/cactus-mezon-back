using Application.Dto.Base;
using Application.Dto.Chat.Message;

namespace WebApi.Contracts.IApplication;

public interface IMessageApplication
{
    public Task<MessageDto> MessageAddAsync(MessageAddDto messageAddDto);
    public Task<PaginationDto<MessageDto>> MessageGetAllAsync(MessageSearchDto messageSearchDto);
    public Task<PaginationDto<MessageDto>> MessageGetAllJustAsync(MessageSearchDto messageSearchDto);
    public Task MessageUpdateAsync(string userPhoneNumber,string groupName);
    public Task GroupUpdateAsync(string userPhoneNumber);
}