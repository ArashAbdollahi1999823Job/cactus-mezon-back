using Application.Common.Messages;
using Application.Dto.StoreUserPicture;
using Application.Dto.TypePicture;
using Application.Features.TypePicture.Command.TypePictureEdit;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.StoreUserPicture.Command.StoreUserPictureEdit;
public class StoreUserPictureEditCommandHandler:IRequestHandler<StoreUserPictureEditCommand,bool>
{
    #region CtorAndInjection
    private readonly IStoreUserPictureRepository _storeUserPictureRepository;
    public StoreUserPictureEditCommandHandler(IStoreUserPictureRepository storeUserPictureRepository)
    {
        _storeUserPictureRepository = storeUserPictureRepository;
    }
    #endregion
    public async Task<bool> Handle(StoreUserPictureEditCommand req, CancellationToken cancellationToken)
    {
        var check =await _storeUserPictureRepository.StoreUserPictureExistAsync(req.Id,cancellationToken);
        if (check)
        {
            StoreUserPictureEditDto storeUserPictureEditDto = new StoreUserPictureEditDto(req.Id, req.PictureAlt, req.PictureTitle, req.Sort, req.IsActive);
            return await _storeUserPictureRepository.StoreUserPictureEditAsync(storeUserPictureEditDto, cancellationToken);
        }

        throw new BadRequestEntityException(ApplicationMessages.TypePictureFailedEditOnHandle);
    }
}