namespace Application.Dto.ProductItem;

public class ProductItemSearchDto
{
    public long Id { get; set; }
    public long ProductId { get; set; }

    public ProductItemSearchDto(long id, long productId)
    {
        Id = id;
        ProductId = productId;
    }

    public ProductItemSearchDto()
    {
    }
}