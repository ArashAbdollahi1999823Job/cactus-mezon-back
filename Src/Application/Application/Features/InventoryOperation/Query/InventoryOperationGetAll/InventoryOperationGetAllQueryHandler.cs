using Application.Dto.Base;
using Application.Dto.InventoryOperation;
using Application.Dto.Store;
using Application.Features.Store.Query.StoreGetAll;
using Application.IContracts.IRepository;
using MediatR;

namespace Application.Features.InventoryOperation.Query.InventoryOperationGetAll;
public class InventoryOperationGetAllQueryHandler:IRequestHandler<InventoryOperationGetAllQuery,PaginationDto<InventoryOperationDto>>
{
    #region CtorAndInjections
    private readonly IInventoryOperationRepository _inventoryOperationRepository;
    public InventoryOperationGetAllQueryHandler(IInventoryOperationRepository inventoryOperationRepository)
    {
        _inventoryOperationRepository = inventoryOperationRepository;
    }
    #endregion
    public async Task<PaginationDto<InventoryOperationDto>> Handle(InventoryOperationGetAllQuery req, CancellationToken cancellationToken)
    {
        var inventoryOperationSearchDto = new InventoryOperationSearchDto(req.Id,req.PageIndex,req.PageSize,req.Price,req.Count,req.InventoryOperationType,req.ProductId,req.InventoryId,req.SortType,req.StoreId);
        return await _inventoryOperationRepository.InventoryOperationGetAllAsync(inventoryOperationSearchDto, cancellationToken);
    }
}