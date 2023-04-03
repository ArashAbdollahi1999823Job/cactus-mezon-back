using Application.Dto.Base;
using Application.Dto.Product;
using Application.Dto.ProductDto;
using Domain.Entities.ProductEntity;

namespace Application.IContracts.IRepository;
public interface IProductRepository
{
    public Task<PaginationDto<ProductDto>> ProductGetAllAsync(ProductSearchDto productSearchDto,CancellationToken cancellationToken);
    public Task<bool> ProductAddAsync(ProductAddDto productAddDto,CancellationToken cancellationToken);
    public Task<bool> ProductEditAsync(ProductEditDto productEditDto, CancellationToken cancellationToken);
    public Task<bool> ProductExistAsync(long id, CancellationToken cancellationToken);
    public Task<bool> ProductDeleteAsync(long id, CancellationToken cancellationToken);
    public Task<Product> ProductGetByIdAsync(long id, CancellationToken cancellationToken);

}