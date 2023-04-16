namespace Application.Dto.Color;

public class ColorAddDto
{
    public string Name { get; set; }
    public string Value { get; set; }
    public long ProductId { set; get; }

    public ColorAddDto(string name, string value, long productId)
    {
        Name = name;
        Value = value;
        ProductId = productId;
    }

    public ColorAddDto()
    {
        
    }
}