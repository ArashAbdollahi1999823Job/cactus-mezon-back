using Application.Common.AutoMapping;
using AutoMapper;

namespace Application.Dto.TypeItem;

public class TypeItemDto:IMapFrom<Domain.Entities.ProductEntity.TypeItem>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid TypeId { get; set; }


    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.ProductEntity.TypeItem, TypeItemDto>();
    }
}