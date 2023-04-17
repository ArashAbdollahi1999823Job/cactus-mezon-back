namespace Domain.Entities.ProductEntity;

public class ProductItem
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    
    public long ProductId { get; set; }
    public Product Product { get; set; }
}