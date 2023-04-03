#region UsingAndNamespace

using Application.Common.AutoMapping;
using Domain.Entities.IdentityEntity;

namespace Application.Dto.IdentityDto;
#endregion
public class AddressDto:IMapFrom<Address>
{
    public long Id { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string FullAddress { get; set; }
    public string PostalCode { get; set; }
    
    
}