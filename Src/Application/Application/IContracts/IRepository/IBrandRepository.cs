using Application.Dto.Base;
using Application.Dto.Brand;
using Application.Dto.Product;
using Application.Dto.ProductDto;
namespace Application.IContracts.IRepository;
public interface IBrandRepository
{
    public Task<PaginationDto<BrandDto>> BrandGetAllAsync(BrandSearchDto productSearchDto,CancellationToken cancellationToken);
    public Task<bool> BrandAddAsync(BrandAddDto brandAddDto,CancellationToken cancellationToken);
    public Task<bool> BrandEditAsync(BrandEditDto brandEditDto, CancellationToken cancellationToken);
    public Task<bool> BrandExistAsync(long id, CancellationToken cancellationToken);
    public Task<bool> BrandDeleteAsync(long id, CancellationToken cancellationToken);
}