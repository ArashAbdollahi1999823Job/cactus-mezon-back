using Domain.Entities.IdentityEntity;
using Domain.Entities.ProductEntity;
using Domain.Enums;
namespace Domain.Entities.InventoryEntity;
public class InventoryOperation:BaseEntity.BaseEntity
{
    public string Description { get; set; }
    public long PriceOperation { get; set; }
    public int Count { get; set; }
    public InventoryOperationType InventoryOperationType { get; set; }

    //has one user
    public User User { get; set; }
    public string UserId { get; set; }
    
    //has one product
    public Product Product { get; set; }
    public long? ProductId { get; set; }
    
    //has one inventory
    public Inventory Inventory { get; set; }
    public long InventoryId { get; set; }
}