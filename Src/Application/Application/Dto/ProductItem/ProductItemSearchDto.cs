namespace Application.Dto.ProductItem;

public class ProductItemSearchDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }

    public ProductItemSearchDto(Guid id, Guid productId)
    {
        Id = id;
        ProductId = productId;
    }

    public ProductItemSearchDto()
    {
    }
}