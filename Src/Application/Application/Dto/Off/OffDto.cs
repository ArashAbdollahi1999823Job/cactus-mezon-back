using Application.Common.AutoMapping;
using AutoMapper;
namespace Application.Dto.Off;

public class OffDto:IMapFrom<Domain.Entities.StoreEntity.Off>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int OffPercent { get; set; }
    

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.StoreEntity.Off, OffDto>();
    } 
}