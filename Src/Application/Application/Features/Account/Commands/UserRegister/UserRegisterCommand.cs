#region UsingAndNamespace
using Application.Common.AutoMapping;
using Application.Dto.Account;
using Application.Dto.User;
using AutoMapper;
using MediatR;
namespace Application.Features.Account.Commands.UserRegister;
#endregion
public class UserRegisterCommand:Dto.Account.UserRegister,IRequest<UserAuthorizeDto>,IMapFrom<Domain.Entities.IdentityEntity.User>
{
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserRegisterCommand, Domain.Entities.IdentityEntity.User>();
    }
}