namespace Domain.Entities.ProductEntity;
public class Color
{
    public Guid Id { get; set; }
    public DateTime? LastModified { get; set; }
    public DateTime CreationDate { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }


    public Color(string name, string value, Guid productId)
    {
        Name = name;
        Value = value;
        ProductId = productId;
    }

    public Product Product { set; get; }
    public Guid ProductId { set; get; }
}