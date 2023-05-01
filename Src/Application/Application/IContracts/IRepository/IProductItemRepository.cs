using Application.Dto.ProductItem;

namespace Application.IContracts.IRepository;
public interface IProductItemRepository
{
    public Task<bool> ProductItemAddAsync(ProductItemAddDto productItemAddDto,CancellationToken cancellationToken);
    public Task<List<ProductItemDto>> ProductItemGetAllAsync(ProductItemSearchDto productItemSearchDto, CancellationToken cancellationToken);
    public Task<bool> ProductItemExistAsync(Guid id,CancellationToken cancellationToken);
    public Task<bool> ProductItemDeleteAsync(Guid id, CancellationToken cancellationToken);
}