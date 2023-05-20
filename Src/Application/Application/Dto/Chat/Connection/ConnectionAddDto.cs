namespace Application.Dto.Chat.Connection;

public class ConnectionAddDto
{
    public string ConnectionId { get; set; }
    public string UserPhoneNumber { get; set; }
    public string UserId { get; set; }
    public Guid GroupId { get; set; }
}