namespace Application.Dto.Inventory;
public class InventoryEditDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public InventoryEditDto(string name, Guid id, bool isActive)
    {
        Name = name;
        Id = id;
        IsActive = isActive;
    }
    public InventoryEditDto()
    {
    }
}