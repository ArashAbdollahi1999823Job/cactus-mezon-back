using Application.Enums;

namespace Application.Dto.Chat.Group;
public class GroupSearchDto
{
    public string Name { get; set; }
    public HasMessageType HasMessage { get; set; } = HasMessageType.NotImportant;

    public GroupSearchDto(string name, HasMessageType hasMessage)
    {
        Name = name;
        HasMessage = hasMessage;
    }
    public GroupSearchDto()
    {
    }
}