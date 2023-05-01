namespace Application.Dto.ProductPicture;

public class ProductPictureSearchDto
{
    public Guid Id { get; set; } 
    public Guid ProductId { get; set; } 
    public int Sort { get; set; } = 0;
    public int StartRange { get; set; } = 0;
    public int EndRange { get; set; } = 0;

    public ProductPictureSearchDto(Guid id, Guid productId, int sort, int startRange, int endRange)
    {
        Id = id;
        ProductId = productId;
        Sort = sort;
        StartRange = startRange;
        EndRange = endRange;
    }

    public ProductPictureSearchDto()
    {
    }
}