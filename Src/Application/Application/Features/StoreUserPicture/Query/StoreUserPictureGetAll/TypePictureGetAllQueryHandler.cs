using Application.Dto.StoreUserPicture;
using Application.Dto.TypePicture;
using Application.Features.TypePicture.Query.TypePictureGetAll;
using Application.IContracts.IRepository;
using MediatR;

namespace Application.Features.StoreUserPicture.Query.StoreUserPictureGetAll;
public class StoreUserPictureGetAllQueryHandler:IRequestHandler<StoreUserPictureGetAllQuery,List<StoreUserPictureDto>>
{
    #region CtorAndInjection
    private readonly IStoreUserPictureRepository _storeUserPictureRepository;
    public StoreUserPictureGetAllQueryHandler(IStoreUserPictureRepository storeUserPictureRepository)
    {
        _storeUserPictureRepository = storeUserPictureRepository;
    }
    #endregion
    public async Task<List<StoreUserPictureDto>> Handle(StoreUserPictureGetAllQuery req, CancellationToken cancellationToken)
    {
        StoreUserPictureSearchDto storeUserPictureSearchDto = new StoreUserPictureSearchDto(req.Id, req.StoreId);
        return await _storeUserPictureRepository.StoreUserPictureGetAllAsync(storeUserPictureSearchDto, cancellationToken);
    }
}