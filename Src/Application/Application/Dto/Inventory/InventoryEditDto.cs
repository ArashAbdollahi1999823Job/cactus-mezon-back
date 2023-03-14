namespace Application.Dto.Inventory;
public class InventoryEditDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public InventoryEditDto(string name, long id, bool isActive)
    {
        Name = name;
        Id = id;
        IsActive = isActive;
    }
    public InventoryEditDto()
    {
    }
}