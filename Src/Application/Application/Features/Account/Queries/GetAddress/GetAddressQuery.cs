#region UsingAndNamespace

using Application.Dto.IdentityDto;
using Domain.Entities.IdentityEntity;
using MediatR;

namespace Application.Features.Account.Queries.GetAddress;
#endregion
public class GetAddressQuery:IRequest<AddressDto>
{
    
}