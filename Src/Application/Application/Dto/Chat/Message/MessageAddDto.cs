using Microsoft.AspNetCore.Http;

namespace Application.Dto.Chat.Message;

public class MessageAddDto
{
    public string AskerPhoneNumber { get; set; }
    public string ResponderPhoneNumber { get; set; }
    public string Content { get; set; }
    public IFormFile Picture { get; set; }
    public string PictureUrl { get; set; }
    public string AskerId { get; set; }
    public string ResponderId { get; set; }
    public Guid GroupId { get; set; }
    public string GroupName { get; set; }


    public MessageAddDto(string askerPhoneNumber, string responderPhoneNumber, string content, IFormFile picture, string askerId, string responderId, Guid groupId, string groupName, string pictureUrl)
    {
        AskerPhoneNumber = askerPhoneNumber;
        ResponderPhoneNumber = responderPhoneNumber;
        Content = content;
        Picture = picture;
        AskerId = askerId;
        ResponderId = responderId;
        GroupId = groupId;
        GroupName = groupName;
        PictureUrl = pictureUrl;
    }
    public MessageAddDto()
    {
    }
}