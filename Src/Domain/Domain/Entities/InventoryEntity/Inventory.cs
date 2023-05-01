using Domain.Entities.ProductEntity;
using Domain.Entities.StoreEntity;
namespace Domain.Entities.InventoryEntity;
public class Inventory
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? LastModified { get; set; }
    public DateTime CreationDate { get; set; }
    public string Name { get; set; }


    //has few InventoryOperation
    public List<InventoryOperation> InventoryOperations { get; set; }
    // has few product
    public List<Product> Products { get; set; }
    //has one shop
    public Guid StoreId { get; set; }
    public Store Store { get; set; }
    
    public Inventory(string name,Guid storeId)
    {
        Name = name;
        StoreId = storeId;
    }
}