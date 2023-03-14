#region UsingAndNamespace

using Application.Dto.Account;
using Application.Dto.User;
using MediatR;
namespace Application.Features.Account.Commands.UserLogin;
#endregion
public class UserLoginCommand:UserLoginDto,IRequest<UserAuthorizeDto>
{
}