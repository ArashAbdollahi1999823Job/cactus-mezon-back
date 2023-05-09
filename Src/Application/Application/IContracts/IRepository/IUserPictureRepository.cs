using Application.Dto.UserPicture;
using Domain.Entities.PictureEntity;
namespace Application.IContracts.IRepository;
public interface IUserPictureRepository
{
    public Task<bool> UserPictureAddAsync(UserPictureAddDto userPictureAddDto,CancellationToken cancellationToken);
    public Task<UserPictureDto> UserPictureGetAllAsync(UserPictureSearchDto userPictureSearchDto, CancellationToken cancellationToken);
    public Task<UserPicture> UserPictureGetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<bool> UserPictureExistAsync(Guid id,CancellationToken cancellationToken);
    public Task<bool> UserPictureDeleteAsync(Guid id, CancellationToken cancellationToken);
}