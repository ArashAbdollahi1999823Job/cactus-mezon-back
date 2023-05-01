using Application.Common.AutoMapping;
using AutoMapper;

namespace Application.Dto.ProductItem;

public class ProductItemDto:IMapFrom<Domain.Entities.ProductEntity.ProductItem>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public Guid ProductId { get; set; }


    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.ProductEntity.ProductItem, ProductItemDto>();
    }
}