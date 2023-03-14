#region UsingAndNamespace

using Application.Common.AutoMapping;
using Application.Dto.IdentityDto;
using AutoMapper;
using Domain.Entities.IdentityEntity;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Application.Features.Account.Commands.CreateAddress;
#endregion
public class CreateAddressCommand:IRequest<AddressDto>,IMapFrom<Address>
{
    public string State { get; set; }
    public string City { get; set; }
    public string FullAddress { get; set; }
    public string PostalCode { get; set; }


    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateAddressCommand, Address>();
    }
}