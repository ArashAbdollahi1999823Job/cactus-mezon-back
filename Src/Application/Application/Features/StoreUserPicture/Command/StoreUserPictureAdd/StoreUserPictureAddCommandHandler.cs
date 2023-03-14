using Application.Common.Messages;
using Application.Dto.StoreUserPicture;
using Application.Dto.TypePicture;
using Application.IContracts.IRepository;
using Application.IContracts.IServices;
using Domain.Exceptions;
using MediatR;
namespace Application.Features.StoreUserPicture.Command.StoreUserPictureAdd;
public class StoreUserPictureAddCommandHandler : IRequestHandler<StoreUserPictureAddCommand, bool>
{
    #region CtorAndInjection
    private readonly IStoreUserPictureRepository _storeUserPictureRepository;
    private readonly IStoreRepository _storeRepository;
    private readonly IFileUploader _fileUploader;
    public StoreUserPictureAddCommandHandler(IFileUploader fileUploader, IStoreRepository storeRepository, IStoreUserPictureRepository storeUserPictureRepository)
    {
        _fileUploader = fileUploader;
        _storeRepository = storeRepository;
        _storeUserPictureRepository = storeUserPictureRepository;
    }
    #endregion


    public async Task<bool> Handle(StoreUserPictureAddCommand req, CancellationToken cancellationToken)
    {
            string storeName = _storeRepository.StoreGetByIdAsync(req.StoreId, cancellationToken).Result.Name;
        var path = $"Picture/Store/{storeName}";
        string pictureUrlString = _fileUploader.Upload(req.PictureUrl, path);
        if (pictureUrlString != null)
        {
            StoreUserPictureAddDto storeUserPictureAddDto = new StoreUserPictureAddDto(req.PictureTitle,req.PictureTitle,pictureUrlString,req.Sort,req.StoreId);
            return await _storeUserPictureRepository.StoreUserPictureAddAsync(storeUserPictureAddDto,cancellationToken);
        }
        throw new BadRequestEntityException(ApplicationMessages.StoreUserPictureFailedAddOnHandle);
    }
}