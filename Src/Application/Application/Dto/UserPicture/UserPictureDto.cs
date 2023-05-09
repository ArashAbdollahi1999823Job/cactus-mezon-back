using Application.Common.AutoMapping;
using AutoMapper;

namespace Application.Dto.UserPicture;
public class UserPictureDto:IMapFrom<Domain.Entities.PictureEntity.UserPicture>
{
    public Guid Id { get; set; }
    public string PictureUrl { get; set; }
    public string User { get; set; }
    public Guid UserId { get; set; }
        
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.PictureEntity.UserPicture,UserPictureDto>()
            .ForMember(x => x.User, c => c.MapFrom(v => v.User.UserName));
    }
}