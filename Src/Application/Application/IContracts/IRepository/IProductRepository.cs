using Application.Dto.ProductDto;

namespace Application.IContracts.IRepository;

public interface IProductRepository
{
    public Task<bool> ProductAddAsync(ProductAddDto productAddDto,CancellationToken cancellationToken);
}