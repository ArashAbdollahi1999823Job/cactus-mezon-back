using Application.Common.AutoMapping;
using AutoMapper;
using Domain.Enums;

namespace Application.Dto.InventoryOperation;
public class InventoryOperationDto:IMapFrom<Domain.Entities.InventoryEntity.InventoryOperation>
{

    public Guid Id { get; set; }
    public string? Description { get; set; }
    public long? Price{ get; set; }
    public int Count { get; set; }
    public string InventoryOperationType { get; set; }

    public string Inventory { get; set; }
    public string Product { get; set; }

    public Guid ProductId { get; set; }
    
    
    #region MappingInventoryOperationDto
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.InventoryEntity.InventoryOperation, InventoryOperationDto>()
            .ForMember(x => x.Product, c => c.MapFrom(v => v.Product.Name))
            .ForMember(x => x.InventoryOperationType, c => c.MapFrom(v => v.InventoryOperationType))
            .ForMember(x => x.Inventory, c => c.MapFrom(v => v.Product.Inventory.Name));
    } 
    #endregion
}