using Application.Common.AutoMapping;
using AutoMapper;

namespace Application.Dto.Brand;

public class BrandDto:IMapFrom<Domain.Entities.ProductEntity.Brand>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public string Summary { get; set; }
    #region MappingBrandDto
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.ProductEntity.Brand, BrandDto>();
    } 
    #endregion
}