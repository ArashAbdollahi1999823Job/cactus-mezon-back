#region UsingAndNamespace
using Domain.Entities.ProductEntity;
using Domain.Entities.StoreEntity;

namespace Domain.Entities.InventoryEntity;
#endregion
public class Inventory:BaseEntity.BaseEntity
{
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