namespace Application.Dto.Color;

public class ColorSearchDto
{
    public long Id { get; set; }
    public long ProductId { set; get; }

    public ColorSearchDto(long id, long productId)
    {
        Id = id;
        ProductId = productId;
    }

    public ColorSearchDto()
    {
        
    }
}