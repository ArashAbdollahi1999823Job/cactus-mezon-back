using Domain.Entities.ProductEntity;
using Domain.Enums;
namespace Domain.Entities.InventoryEntity;
public class InventoryOperation
{
    public Guid Id { get; set; }
    public DateTime? LastModified { get; set; }
    public DateTime CreationDate { get; set; }
    public string? Description { get; set; }
    public long? Price{ get; set; }
    public int Count { get; set; }
    public string InventoryOperationType { get; set; }
    
    public InventoryOperation(string description, long? price, int count, string inventoryOperationType, Guid? productId)
    {
        Description = description;
        Price = price;
        Count = count;
        InventoryOperationType = inventoryOperationType;
        ProductId = productId;
    }
    public Product Product { get; set; }
    public Guid? ProductId { get; set; }
}