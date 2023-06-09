#region UsingAndNamespace

using Application.Dto.Identity;
using MediatR;
namespace Application.Features.Account.Commands.UserRegister;
#endregion
public class UserRegisterCommand:Dto.Account.UserRegister,IRequest<RegisterReturnDto>
{
    
 
}