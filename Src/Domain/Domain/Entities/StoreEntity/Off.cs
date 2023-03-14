using Domain.Entities.ProductEntity;
namespace Domain.Entities.StoreEntity;
public class Off:BaseEntity.BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int OffPercent { get; set; }
    

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }


    public List<Product> Products { get; set; }
}