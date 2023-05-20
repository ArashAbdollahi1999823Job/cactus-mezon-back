namespace Application.Dto.Chat.Group;
public class GroupAddDto
{
    public string ResponderPhoneNumber { get; set; }
    public string Name { get; set; }
    public string ResponderId { get; set; }
    public string AskerId { get; set; }

    public GroupAddDto(string name, string responderId, string askerId)
    {
        Name = name;
        ResponderId = responderId;
        AskerId = askerId;
    }
    public GroupAddDto()
    {
    }
}