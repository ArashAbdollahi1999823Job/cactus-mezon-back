using Application.Dto.Base;
using Application.Dto.Product;
using Domain.Entities.ProductEntity;
using Domain.Enums;

namespace Application.IContracts.IRepository;
public interface IProductRepository
{
    public Task<PaginationDto<ProductDto>> ProductGetAllAsync(ProductSearchDto productSearchDto,CancellationToken cancellationToken);
    public Task<bool> ProductAddAsync(ProductAddDto productAddDto,CancellationToken cancellationToken);
    public Task<bool> ProductEditAsync(ProductEditDto productEditDto, CancellationToken cancellationToken);
    public Task<bool> ProductExistAsync(Guid id, CancellationToken cancellationToken);
    public Task<bool> ProductDeleteAsync(Guid id, CancellationToken cancellationToken);
    public Task<Product> ProductGetByIdAsync(Guid id, CancellationToken cancellationToken);

    public Task<bool> ProductChangeCountAsync(int count, string inventoryOperationType, Guid productId,
        CancellationToken cancellationToken);

}