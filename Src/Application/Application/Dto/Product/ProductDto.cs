using Application.Common.AutoMapping;
using Application.Dto.Color;
using Application.Dto.Off;
using Application.Dto.ProductItem;
using AutoMapper;

namespace Application.Dto.Product;

public class ProductDto:IMapFrom<Domain.Entities.ProductEntity.Product>
{
    public Guid Id { get; set; }
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
    public string SellerPhoneNumber { get; set; }
    
    public string Type { get; set; }
    public Guid TypeId { get; set; }

    public string Brand { get; set; }
    public string Inventory { get; set; }
    public Guid InventoryId { get; set; }

    public OffDto Off { get; set; }
    public Guid OffId { get; set; }

    public List<ColorDto> ColorDtos { get; set; }
    public List<ProductItemDto> ProductItemDtos { get; set; }



    #region MappingProductDto
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.ProductEntity.Product, ProductDto>()
            .ForMember(x => x.Store, c => c.MapFrom(v => v.Inventory.Store.Name))
            .ForMember(x => x.SellerPhoneNumber, c => c.MapFrom(v => v.Inventory.Store.User.PhoneNumber))
            .ForMember(x => x.Inventory, c => c.MapFrom(v => v.Inventory.Name))
            .ForMember(x => x.Brand, c => c.MapFrom(v => v.Brand.Name))
            .ForMember(x => x.Type, c => c.MapFrom(v => v.Type.Name))
            .ForMember(x => x.Off, c => c.MapFrom(v => v.Off))
            .ForMember(x => x.ColorDtos, c => c.MapFrom(v => v.Colors))
            .ForMember(x => x.ProductItemDtos, c => c.MapFrom(v => v.ProductItems));
    } 
    #endregion
}

