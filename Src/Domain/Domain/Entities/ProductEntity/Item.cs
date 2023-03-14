namespace Domain.Entities.ProductEntity;

public class Item:BaseEntity.BaseEntity
{
    public string Name { get; set; }
    public string Value { get; set; }


    public List<Type> Types { get; set; }
    public List<Product> Products { get; set; }
    
}