using Application.Common.Messages;
using Application.IContracts.IRepository;
using Application.IContracts.IServices;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.UserPicture.Command.UserPictureDelete;
public class UserPictureCommandHandler:IRequestHandler<UserPictureDeleteCommand,bool>
{
    #region CtorAndInjection
    private readonly IUserPictureRepository _typePictureRepository;
    private readonly IFileUploader _fileUploader;
    public UserPictureCommandHandler(IUserPictureRepository typePictureRepository, IFileUploader fileUploader)
    {
        _typePictureRepository = typePictureRepository;
        _fileUploader = fileUploader;
    }
    #endregion
    public async Task<bool> Handle(UserPictureDeleteCommand req, CancellationToken cancellationToken)
    {
        var typePicture =await _typePictureRepository.UserPictureGetByIdAsync(req.Id, cancellationToken);
        var checkDeleteFile =  _fileUploader.Delete(typePicture.PictureUrl);
        if (checkDeleteFile)
        {
           return await _typePictureRepository.UserPictureDeleteAsync(req.Id,cancellationToken);
        }
        throw new BadRequestEntityException(ApplicationMessages.UserPictureFailedDeleteOnHandle);
    }
}