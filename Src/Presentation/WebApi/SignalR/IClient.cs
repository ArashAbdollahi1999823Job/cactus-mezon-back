using Application.Dto.Message;
namespace WebApi.SignalR;

public interface IClient
{
    Task SetGroupName(string? groupName);

    Task ShowNewMessage(MessageDto messageDto);

    Task TestSuccess();
    Task UpdateMessages(List<MessageDto> messageDtos);
    Task ShowNewGroup();
}