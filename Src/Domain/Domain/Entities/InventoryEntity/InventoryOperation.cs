using Domain.Entities.ProductEntity;
using Domain.Enums;
namespace Domain.Entities.InventoryEntity;
public class InventoryOperation:BaseEntity.BaseEntity
{
    public string Description { get; set; }
    public long Price{ get; set; }
    public int Count { get; set; }
    public InventoryOperationType InventoryOperationType { get; set; }

    //has one product
    public Product Product { get; set; }
    public long? ProductId { get; set; }
}