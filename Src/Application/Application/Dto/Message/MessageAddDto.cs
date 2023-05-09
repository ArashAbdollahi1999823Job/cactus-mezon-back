namespace Application.Dto.Message;

public class MessageAddDto
{
    public string AskerPhoneNumber { get; set; }
    public string ResponderPhoneNumber { get; set; }
    public string Content { get; set; }
    public string PictureUrl { get; set; }

    public string AskerId { get; set; }
    public string ResponderId { get; set; }


    public MessageAddDto(string askerPhoneNumber, string responderPhoneNumber, string content, string pictureUrl, string askerId, string responderId)
    {
        AskerPhoneNumber = askerPhoneNumber;
        ResponderPhoneNumber = responderPhoneNumber;
        Content = content;
        PictureUrl = pictureUrl;
        AskerId = askerId;
        ResponderId = responderId;
    }

    public MessageAddDto()
    {
        
    }
}