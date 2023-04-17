using Application.Dto.ProductItem;
using Domain.Entities.ProductEntity;

namespace Application.IContracts.IRepository;
public interface IProductItemRepository
{
    public Task<bool> ProductItemAddAsync(ProductItemAddDto productItemAddDto,CancellationToken cancellationToken);
    public Task<List<ProductItemDto>> ProductItemGetAllAsync(ProductItemSearchDto productItemSearchDto, CancellationToken cancellationToken);
    public Task<ProductItem> ProductItemGetByIdAsync(long id, CancellationToken cancellationToken);
    public Task<bool> ProductItemExistAsync(long id,CancellationToken cancellationToken);
    public Task<bool> ProductItemDeleteAsync(long id, CancellationToken cancellationToken);
}