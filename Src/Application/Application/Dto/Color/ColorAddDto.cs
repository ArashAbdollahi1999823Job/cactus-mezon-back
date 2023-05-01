namespace Application.Dto.Color;

public class ColorAddDto
{
    public string Name { get; set; }
    public string Value { get; set; }
    public Guid ProductId { set; get; }

    public ColorAddDto(string name, string value, Guid productId)
    {
        Name = name;
        Value = value;
        ProductId = productId;
    }

    public ColorAddDto()
    {
        
    }
}