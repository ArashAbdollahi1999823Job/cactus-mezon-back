using Application.Dto.StoreUserPicture;
using Domain.Entities.PictureEntity;

namespace Application.IContracts.IRepository;
public interface IStoreUserPictureRepository
{
    public Task<bool> StoreUserPictureAddAsync(StoreUserPictureAddDto storeUserPictureAddDto,CancellationToken cancellationToken);
    public Task<List<StoreUserPictureDto>> StoreUserPictureGetAllAsync(StoreUserPictureSearchDto storeUserPictureSearchDto, CancellationToken cancellationToken);
    public Task<bool> StoreUserPictureEditAsync(StoreUserPictureEditDto storeUserPictureEditDto, CancellationToken cancellationToken);
    public Task<StorePicture> StoreUserPictureGetByIdAsync(long id, CancellationToken cancellationToken);
    public Task<bool> StoreUserPictureExistAsync(long id,CancellationToken cancellationToken);
    public Task<bool> StoreUserPictureDeleteAsync(long id, CancellationToken cancellationToken);
}