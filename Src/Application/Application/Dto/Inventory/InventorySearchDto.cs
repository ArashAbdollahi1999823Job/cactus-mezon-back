using Application.Enums;

namespace Application.Dto.Inventory;

public class InventorySearchDto
{
    public long Id { get; set; }
    public string Name { get; set; }

    public long StoreId { get; set; }
    public ActiveType IsActive { get; set; } = ActiveType.NotImportant;


    
    public InventorySearchDto(long id,long storeId,string name,ActiveType isActive)
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