using Application.Dto.Base;
using Application.Dto.Brand;
using Application.Dto.Product;

namespace Application.IContracts.IRepository;
public interface IBrandRepository
{
    public Task<PaginationDto<BrandDto>> BrandGetAllAsync(BrandSearchDto productSearchDto,CancellationToken cancellationToken);
    public Task<bool> BrandAddAsync(BrandAddDto brandAddDto,CancellationToken cancellationToken);
    public Task<bool> BrandEditAsync(BrandEditDto brandEditDto, CancellationToken cancellationToken);
    public Task<bool> BrandExistAsync(Guid id, CancellationToken cancellationToken);
    public Task<bool> BrandDeleteAsync(Guid id, CancellationToken cancellationToken);
}