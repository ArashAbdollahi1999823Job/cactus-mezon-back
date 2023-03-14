using Application.Dto.Base;
using Application.Dto.Store;
using Application.IContracts.IRepository;
using MediatR;
namespace Application.Features.Store.Query.StoreGetAll;
public class StoreGetAllQueryHandler:IRequestHandler<StoreGetAllQuery,PaginationDto<StoreDto>>
{
    #region CtorAndInjections
    private readonly IStoreRepository _storeRepository;
    public StoreGetAllQueryHandler(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }
    #endregion
    public async Task<PaginationDto<StoreDto>> Handle(StoreGetAllQuery req, CancellationToken cancellationToken)
    {
        var storeSearchDto = new StoreSearchDto(req.Id, req.PageIndex, req.PageSize, req.Name, req.PhoneNumber,req.MobileNumber, req.ActiveType, req.UserId, req.SortType);
        return await _storeRepository.StoreGetAllAsync(storeSearchDto, cancellationToken);
    }
}