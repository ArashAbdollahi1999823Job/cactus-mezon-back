using Application.Common.AutoMapping;
using AutoMapper;

namespace Application.Dto.Chat.Group;

public class GroupDto:IMapFrom<Domain.Entities.ChatEntity.Group>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public string ResponderId { get; set; }
    public string Responder { get; set; }
    public string ResponderPhoneNumber { get; set; }

    public string AskerId { get; set; }
    public string Asker { get; set; }
    public string AskerPhoneNumber { get; set; }
    
    #region MappingGroupDto
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.ChatEntity.Group, GroupDto>()
            .ForMember(x => x.AskerPhoneNumber, c => c.MapFrom(v => v.Asker.PhoneNumber))
            .ForMember(x => x.ResponderPhoneNumber, c => c.MapFrom(v => v.Responder.PhoneNumber))
            .ForMember(x => x.Asker, c => c.MapFrom(v => v.Asker.UserName))
            .ForMember(x => x.Responder, c => c.MapFrom(v => v.Responder.UserName));
    } 
    #endregion

}