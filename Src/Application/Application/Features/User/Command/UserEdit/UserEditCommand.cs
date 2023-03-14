using Application.Dto.User;
using MediatR;
namespace Application.Features.User.Command.UserEdit;
public class UserEditCommand:UserEditDto,IRequest<bool>
{
   
}