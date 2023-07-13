using Application.Common.AutoMapping;
using AutoMapper;

namespace Application.Dto.StoreUser;
public class StoreUserDto:IMapFrom<Domain.Entities.StoreEntity.Store>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string MobileNumber { get; set; }
    public string Description { get; set; }

    public string  User { get; set; }
    public string UserId { get; set; }

    public string Slug { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.StoreEntity.Store, StoreUserDto>()
            .ForMember(x => x.User, x => x.MapFrom(x => x.User.UserName));
    }
    
}