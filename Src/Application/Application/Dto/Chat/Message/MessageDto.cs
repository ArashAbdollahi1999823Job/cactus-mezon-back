using Application.Common.AutoMapping;
using AutoMapper;

namespace Application.Dto.Chat.Message;

public class MessageDto:IMapFrom<Domain.Entities.ChatEntity.Message>
{
    public Guid Id { get; set; }
    public bool IsRead { get; set; }
    public string AskerPhoneNumber { get; set; }
    public string ResponderPhoneNumber { get; set; }
    public string Content { get; set; }
    public string PictureUrl { get; set; }
    public string GroupName { get; set; }
    public DateTime CreationDate { get; set; }

    public string AskerId { get; set; }
    public string ResponderId { get; set; }
    public Guid GroupId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.ChatEntity.Message, MessageDto>().ReverseMap();
    }
}