using Application.Common.AutoMapping;
using AutoMapper;
namespace Application.Dto.Account;
public class UserAuthorizeDto:IMapFrom<Domain.Entities.IdentityEntity.User>
{
    #region Properties
    public string Username { get; set; }
    public string Token { get; set; }
    #endregion

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.IdentityEntity.User, UserAuthorizeDto>().ReverseMap();
    }
}