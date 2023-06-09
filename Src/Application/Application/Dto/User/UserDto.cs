using Application.Common.AutoMapping;
using Application.Dto.IdentityDto;
using Application.Dto.UserPicture;
using AutoMapper;
namespace Application.Dto.User;
public class UserDto : IMapFrom<Domain.Entities.IdentityEntity.User>
{
    public string Username { get; set; }
    public string PhoneNumber { get; set; }
    public string Id { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public string Password { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }


    public UserPictureDto UserPictureDto { set; get; }


    public IEnumerable<RoleDto> Roles { set; get; }

    #region MappingUserDto

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.IdentityEntity.User, UserDto>()
            .ForMember(x => x.Roles, c => c.MapFrom(v => v.UserRoles.Select(x => x.Role.Name)))
            .ForMember(x => x.Roles, c => c.MapFrom(v => v.UserRoles.Select(x => new RoleDto() { Id = x.Role.Id, Name = x.Role.Name })))
            .ForMember(x => x.UserPictureDto, c => c.MapFrom(v => v.UserPicture))
            .ReverseMap();

        /*  .ForMember(x=>x.RoleId,c=>c.MapFrom(v=>v.UserRoles.Select(x=>x.Role.Id)));*/
    }

    #endregion
}