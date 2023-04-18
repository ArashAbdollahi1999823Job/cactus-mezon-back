namespace Application.Dto.ProductPicture;

public class ProductPictureSearchDto
{
    public long Id { get; set; } = 0;
    public long ProductId { get; set; } = 0;
    public int Sort { get; set; } = 0;
    public int StartRange { get; set; } = 0;
    public int EndRange { get; set; } = 0;

    public ProductPictureSearchDto(long id, long productId, int sort, int startRange, int endRange)
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