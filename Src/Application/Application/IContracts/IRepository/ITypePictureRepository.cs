using Application.Dto.TypePicture;
using Domain.Entities.PictureEntity;
namespace Application.IContracts.IRepository;
public interface ITypePictureRepository
{
    public Task<bool> TypePictureAddAsync(TypePictureAddDto typePictureAddDto,CancellationToken cancellationToken);
    public Task<List<TypePictureDto>> TypePictureGetAllAsync(TypePictureSearchDto typePictureSearchDto, CancellationToken cancellationToken);
    public Task<bool> TypePictureEditAsync(TypePictureEditDto typePictureEditDto, CancellationToken cancellationToken);
    public Task<TypePicture> TypePictureGetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<bool> TypePictureExistAsync(Guid id,CancellationToken cancellationToken);
    public Task<bool> TypePictureDeleteAsync(Guid id, CancellationToken cancellationToken);
}