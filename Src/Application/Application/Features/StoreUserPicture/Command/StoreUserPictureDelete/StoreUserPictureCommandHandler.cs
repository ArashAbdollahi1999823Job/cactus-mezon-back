using Application.Common.Messages;
using Application.IContracts.IRepository;
using Application.IContracts.IServices;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.StoreUserPicture.Command.StoreUserPictureDelete;
public class StoreUserPictureCommandHandler:IRequestHandler<StoreUserPictureDeleteCommand,bool>
{
    #region CtorAndInjection
    private readonly IStoreUserPictureRepository _storeUserPictureRepository;
    private readonly IFileUploader _fileUploader;
    public StoreUserPictureCommandHandler(IStoreUserPictureRepository storeUserPictureRepository, IFileUploader fileUploader)
    {
        _storeUserPictureRepository = storeUserPictureRepository;
        _fileUploader = fileUploader;
    }
    #endregion
    public async Task<bool> Handle(StoreUserPictureDeleteCommand req, CancellationToken cancellationToken)
    {
        var storePicture =await _storeUserPictureRepository.StoreUserPictureGetByIdAsync(req.Id, cancellationToken);
        var checkDeleteFile =  _fileUploader.Delete(storePicture.PictureUrl);
        if (checkDeleteFile)
        {
           return await _storeUserPictureRepository.StoreUserPictureDeleteAsync(req.Id,cancellationToken);
        }
        throw new BadRequestEntityException(ApplicationMessages.TypePictureFailedDeleteOnHandle);
    }
}