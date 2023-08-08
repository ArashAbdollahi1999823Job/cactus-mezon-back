using Application.Dto.StoreUser;
using Application.IContracts.IBehaviourPipe;
using MediatR;

namespace Application.Features.StoreUser.Query.StoreUserGet;
public class StoreUserGetQuery:StoreUserSearchDto,IRequest<StoreUserDto>
{
}