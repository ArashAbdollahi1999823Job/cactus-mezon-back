using Application.Enums;

namespace Application.Dto.Inventory;

public class InventorySearchDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid StoreId { get; set; }
    public ActiveType IsActive { get; set; } = ActiveType.NotImportant;


    
    public InventorySearchDto(Guid id,Guid storeId,string name,ActiveType isActive)
    {
        StoreId = storeId;
        Id = id;
        Name = name;
        IsActive = isActive;
    }

    public InventorySearchDto()
    {
        
    }
}