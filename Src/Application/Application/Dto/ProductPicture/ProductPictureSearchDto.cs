namespace Application.Dto.ProductPicture;

public class ProductPictureSearchDto
{
    public long Id { get; set; } = 0;
    public long ProductId { get; set; } = 0;

    public ProductPictureSearchDto(long id, long productId)
    {
        Id = id;
        ProductId = productId;
    }

    public ProductPictureSearchDto()
    {
        
    }
}