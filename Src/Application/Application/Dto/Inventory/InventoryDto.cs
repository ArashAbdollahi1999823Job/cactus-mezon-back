using Application.Common.AutoMapping;
using AutoMapper;

namespace Application.Dto.Inventory;

public class InventoryDto:IMapFrom<Domain.Entities.InventoryEntity.Inventory>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.InventoryEntity.Inventory, InventoryDto>();
    }
}