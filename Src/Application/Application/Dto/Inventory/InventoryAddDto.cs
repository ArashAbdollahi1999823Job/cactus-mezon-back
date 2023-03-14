namespace Application.Dto.Inventory;
public class InventoryAddDto
{
    
    public string Name { get; set; }

    public long StoreId { get; set; }

    public InventoryAddDto(string name, long storeId)
    {
        Name = name;
        StoreId = storeId;
    }

    public InventoryAddDto()
    {
        
    }
}