using Application.Dto.StoreUser;
using MediatR;

namespace Application.Features.StoreUser.Query.StoreUserGet;
public class StoreUserGetQuery:StoreUserSearchDto,IRequest<StoreUserDto>
{
    
}