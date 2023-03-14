using Application.Common.AutoMapping;
using AutoMapper;
namespace Application.Dto.Type;
public class TypeDto:IMapFrom<Domain.Entities.ProductEntity.Type>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public string Summary { get; set; }
    public bool IsActive { get; set; }
    public long? ParentTypeId { get; set; }
    public string?  ParentType { get; set; }
    
    #region MappingTypeDto
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.ProductEntity.Type,TypeDto>()
            .ForMember(x => x.ParentType, c => c.MapFrom(v => v.ParentType.Name));
    } 
    #endregion
}