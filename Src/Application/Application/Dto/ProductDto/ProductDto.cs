#region UsingAndNamespace

using Application.Common.AutoMapping;
using Application.Common.AutoMapping.Resolvers;
using Application.Dto.CommonDto;
using AutoMapper;
using Domain.Entities.ProductEntity;

namespace Application.Dto.ProductsDto;
#endregion
public class ProductDto:CommandDto,IMapFrom<Product>
{
    #region Properties
    public long Id { get; set; }
    public string Title { get; set; }
    public string PictureThumbnailUrl { get; set; }
    public string MetaDescription { get; set; }
    public decimal Price { get; set; }
    public string Slug { get; set; }
    #endregion

    #region RilationsDto
    public string ProductType { get; set; }//=>Title of ProductType
    public string ProductBrand { get; set; }//=>Title of ProductBrand
    public long ProductTypeId { get; set; }
    public long ProductBrandId { get; set; }
    #endregion

    #region MappingProductDto
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductDto>()
            .ForMember(x=>x.PictureThumbnailUrl,c=>c.MapFrom<ProductPictureThumbnailResolver>())
            .ForMember(x => x.ProductBrand, c => c.MapFrom(v => v.Brand.Name))
            .ForMember(x => x.ProductType, c => c.MapFrom(v => v.Type.Name));
    } 
    #endregion
}

