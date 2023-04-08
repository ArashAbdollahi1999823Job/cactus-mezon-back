namespace Application.Dto.Inventory;
public class InventoryAddDto
{
    
    public string Name { get; set; }

    public Guid StoreId { get; set; }

    public InventoryAddDto(string name, Guid storeId)
    {
        Name = name;
        StoreId = storeId;
    }

    public InventoryAddDto()
    {
        
    }
}