using Application.Common.AutoMapping;
using Application.Dto.Off;
using AutoMapper;
using Domain.Entities.ProductEntity;
namespace Application.Dto.ProductDto;

public class ProductDto:IMapFrom<Product>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public decimal Price { get; set; }
    public string Summary { get; set; }
    public long Score { get; set; }
    public int Count { get; set; }
    public bool IsActive { get; set; }
    public string Store { get; set; }
    
    public string Type { get; set; }
    public string Brand { get; set; }
    public string Inventory { get; set; }
    public OffDto Off { get; set; }



    #region MappingProductDto
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductDto>()
            .ForMember(x => x.Store, c => c.MapFrom(v => v.Inventory.Store.Name))
            .ForMember(x => x.Inventory, c => c.MapFrom(v => v.Inventory.Name))
            .ForMember(x => x.Brand, c => c.MapFrom(v => v.Brand.Name))
            .ForMember(x => x.Type, c => c.MapFrom(v => v.Type.Name))
            .ForMember(x => x.Off, c => c.MapFrom(v => v.Off));
    } 
    #endregion
}

