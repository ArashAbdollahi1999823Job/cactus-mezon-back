using Application.Common.AutoMapping;
using AutoMapper;

namespace Application.Dto.Color;

public class ColorDto:IMapFrom<Domain.Entities.ProductEntity.Color>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.ProductEntity.Color, ColorDto>();
    } 
}