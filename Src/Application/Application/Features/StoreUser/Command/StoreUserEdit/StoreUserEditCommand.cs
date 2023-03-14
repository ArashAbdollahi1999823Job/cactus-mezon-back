using Application.Dto.StoreUser;
using MediatR;
namespace Application.Features.StoreUser.Command.StoreUserEdit;
public class StoreUserEditCommand:StoreUserEditDto,IRequest<bool>
{
}