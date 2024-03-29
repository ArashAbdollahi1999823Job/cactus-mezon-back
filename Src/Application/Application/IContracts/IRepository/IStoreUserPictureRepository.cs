﻿using Application.Dto.StoreUserPicture;
using Domain.Entities.PictureEntity;

namespace Application.IContracts.IRepository;
public interface IStoreUserPictureRepository
{
    public Task<bool> StoreUserPictureAddAsync(StoreUserPictureAddDto storeUserPictureAddDto,CancellationToken cancellationToken);
    public Task<List<StoreUserPictureDto>> StoreUserPictureGetAllAsync(StoreUserPictureSearchDto storeUserPictureSearchDto, CancellationToken cancellationToken);
    public Task<bool> StoreUserPictureEditAsync(StoreUserPictureEditDto storeUserPictureEditDto, CancellationToken cancellationToken);
    public Task<StorePicture> StoreUserPictureGetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<bool> StoreUserPictureExistAsync(Guid id,CancellationToken cancellationToken);
    public Task<bool> StoreUserPictureDeleteAsync(Guid id, CancellationToken cancellationToken);
}