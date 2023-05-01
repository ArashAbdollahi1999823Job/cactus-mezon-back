using Application.Dto.ProductPicture;
using Domain.Entities.PictureEntity;
namespace Application.IContracts.IRepository;
public interface IProductPictureRepository
{
    public Task<bool> ProductPictureAddAsync(ProductPictureAddDto productPictureAddDto,CancellationToken cancellationToken);
    public Task<List<ProductPictureDto>> ProductPictureGetAllAsync(ProductPictureSearchDto productPictureSearchDto, CancellationToken cancellationToken);
    public Task<bool> ProductPictureEditAsync(ProductPictureEditDto productPictureEditDto, CancellationToken cancellationToken);
    public Task<ProductPicture> ProductPictureGetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<bool> ProductPictureExistAsync(Guid id,CancellationToken cancellationToken);
    public Task<bool> ProductPictureDeleteAsync(Guid id, CancellationToken cancellationToken);
}