using Application.Common.AutoMapping;
using AutoMapper;
namespace Application.Dto.Type;
public class TypeDto:IMapFrom<Domain.Entities.ProductEntity.Type>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public string Summary { get; set; }
    public bool IsActive { get; set; }
    public Guid? ParentTypeId { get; set; }
    public string?  ParentType { get; set; }
    public string Sort { get; set; }
    
    #region MappingTypeDto
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.ProductEntity.Type,TypeDto>()
            .ForMember(x => x.ParentType, c => c.MapFrom(v => v.ParentType.Name));
    } 
    #endregion
}