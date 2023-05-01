using Domain.Enums;

namespace Application.Dto.InventoryOperation;

public class InventoryOperationAddDto
{
    public string? Description { get; set; }
    public long? Price{ get; set; }
    public int Count { get; set; }
    public string InventoryOperationType { get; set; }

    public Guid ProductId { get; set; }

    public InventoryOperationAddDto(string description, long? price, int count, string inventoryOperationType, Guid productId)
    {
        Description = description;
        Price = price;
        Count = count;
        InventoryOperationType = inventoryOperationType;
        ProductId = productId;
    }

    public InventoryOperationAddDto()
    {
        
    }
}