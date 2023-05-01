using Domain.Entities.ProductEntity;
namespace Domain.Entities.StoreEntity;
public class Off
{
    public Guid Id { get; set; }
    
    public DateTime? LastModified { get; set; }
    public DateTime CreationDate { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int OffPercent { get; set; }
    

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }


    public Store Store { get; set; }
    public Guid  StoreId { get; set; }
    
    public List<Product>? Products { get; set; }

    public Off(string name, string description, int offPercent, DateTime startDate, DateTime endDate, Guid storeId)
    {
        Name = name;
        Description = description;
        OffPercent = offPercent;
        StartDate = startDate;
        EndDate = endDate;
        StoreId = storeId;
    }
}