using Application.Common.Messages;
using Application.IContracts.IRepository;
using Application.IContracts.IServices;
using Domain.Exceptions;
using MediatR;
namespace Application.Features.TypePicture.Command.TypePictureDelete;
public class TypePictureCommandHandler:IRequestHandler<TypePictureDeleteCommand,bool>
{
    #region CtorAndInjection
    private readonly ITypePictureRepository _typePictureRepository;
    private readonly IFileUploader _fileUploader;
    public TypePictureCommandHandler(ITypePictureRepository typePictureRepository, IFileUploader fileUploader)
    {
        _typePictureRepository = typePictureRepository;
        _fileUploader = fileUploader;
    }
    #endregion
    public async Task<bool> Handle(TypePictureDeleteCommand req, CancellationToken cancellationToken)
    {
        var typePicture =await _typePictureRepository.TypePictureGetByIdAsync(req.Id, cancellationToken);
        var checkDeleteFile =  _fileUploader.Delete(typePicture.PictureUrl);
        if (checkDeleteFile)
        {
           return await _typePictureRepository.TypePictureDeleteAsync(req.Id,cancellationToken);
        }
        throw new BadRequestEntityException(ApplicationMessages.TypePictureFailedDeleteOnHandle);
    }
}