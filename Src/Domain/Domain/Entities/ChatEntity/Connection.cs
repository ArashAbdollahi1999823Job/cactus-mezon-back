using Domain.Entities.IdentityEntity;

namespace Domain.Entities.ChatEntity;
public class Connection
{
    public Guid Id { get; set; }
    public string ConnectionId { get; set; }
    public string UserPhoneNumber { get; set; }

    public string UserId { get; set; }
    public User User { get; set; }
    
    public Guid GroupId { get; set; }
    public Group Group { get; set; }

    public Connection( string connectionId, string userPhoneNumber, string userId, Guid groupId)
    {
        ConnectionId = connectionId;
        UserPhoneNumber = userPhoneNumber;
        UserId = userId;
        GroupId = groupId;
    }
}