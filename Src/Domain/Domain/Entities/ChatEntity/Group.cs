using Domain.Entities.IdentityEntity;

namespace Domain.Entities.ChatEntity;

public class Group
{
    public Guid Id { get; set; }
    public string Name { get; set; }


    public string ResponderId { get; set; }
    public User Responder { get; set; }

    public string AskerId { get; set; }
    public User Asker { get; set; }

    public ICollection<Connection> Connections { get; set; }
    public ICollection<Message> Messages { get; set; }

    public Group( string name, string responderId, string askerId)
    {
        Name = name;
        ResponderId = responderId;
        AskerId = askerId;
    }
}