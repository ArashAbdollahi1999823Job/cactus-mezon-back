using Application.Dto.Chat.Message;

namespace WebApi.SignalR;

public interface IClient
{
    Task UpdateMessage();
    Task SetGroupName(string? groupName);

    Task ShowNewMessage(MessageDto messageDto);

    Task TestSuccess();
    Task UpdateMessages(List<MessageDto> messageDtos);
    Task ShowNewGroup();
}