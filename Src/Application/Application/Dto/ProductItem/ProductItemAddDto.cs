namespace Application.Dto.ProductItem;

public class ProductItemAddDto
{
    public string Name { get; set; }
    public string Value { get; set; }

    public Guid ProductId { get; set; }

    public ProductItemAddDto(string name, Guid productId, string value)
    {
        Name = name;
        ProductId = productId;
        Value = value;
    }

    public ProductItemAddDto()
    {
    }
}