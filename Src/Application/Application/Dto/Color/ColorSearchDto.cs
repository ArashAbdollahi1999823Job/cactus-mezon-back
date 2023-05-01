namespace Application.Dto.Color;

public class ColorSearchDto
{
    public Guid Id { get; set; }
    public Guid ProductId { set; get; }

    public ColorSearchDto(Guid id, Guid productId)
    {
        Id = id;
        ProductId = productId;
    }

    public ColorSearchDto()
    {
        
    }
}