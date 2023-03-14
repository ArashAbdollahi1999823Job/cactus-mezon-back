#region UsingAndNamespace

using Application.Dto.User;
using MediatR;

namespace Application.Features.User.Command.UserAdd;
#endregion
public class UserAddCommand:UserAddDto,IRequest<bool>
{

}