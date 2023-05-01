namespace Domain.Entities.ProductEntity;

public class ProductItem
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }

    public ProductItem(string name, string value, Guid productId)
    {
        Name = name;
        Value = value;
        ProductId = productId;
    }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}