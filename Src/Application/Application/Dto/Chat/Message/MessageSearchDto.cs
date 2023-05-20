using Application.Enums;

namespace Application.Dto.Chat.Message;

public class MessageSearchDto
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 100;
    
    public Guid Id { get; set; }
    public IsReadType IsRead { get; set; } = IsReadType.NotImportant;
    public string AskerPhoneNumber { get; set; }
    public string ResponderPhoneNumber { get; set; }
    public string GroupName { get; set; }
}