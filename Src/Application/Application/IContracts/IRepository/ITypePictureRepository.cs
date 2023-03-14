using Application.Dto.TypePicture;
using Domain.Entities.PictureEntity;
namespace Application.IContracts.IRepository;
public interface ITypePictureRepository
{
    public Task<bool> TypePictureAddAsync(TypePictureAddDto typePictureAddDto,CancellationToken cancellationToken);
    public Task<List<TypePictureDto>> TypePictureGetAllAsync(TypePictureSearchDto typePictureSearchDto, CancellationToken cancellationToken);
    public Task<bool> TypePictureEditAsync(TypePictureEditDto typePictureEditDto, CancellationToken cancellationToken);
    public Task<TypePicture> TypePictureGetByIdAsync(long id, CancellationToken cancellationToken);
    public Task<bool> TypePictureExistAsync(long id,CancellationToken cancellationToken);
    public Task<bool> TypePictureDeleteAsync(long id, CancellationToken cancellationToken);
}