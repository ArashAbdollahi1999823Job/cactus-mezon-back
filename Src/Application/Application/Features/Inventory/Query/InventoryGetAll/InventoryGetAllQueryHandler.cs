using Application.Dto.Inventory;
using Application.IContracts.IRepository;
using MediatR;

namespace Application.Features.Inventory.Query.InventoryGetAll;

public class InventoryGetAllQueryHandler:IRequestHandler<InventoryGetAllQuery,IEnumerable<InventoryDto>>
{
    #region CtorAndInjection
    private readonly IInventoryRepository _inventoryRepository;
    public InventoryGetAllQueryHandler(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }
    #endregion
    public async Task<IEnumerable<InventoryDto>> Handle(InventoryGetAllQuery req, CancellationToken cancellationToken)
    {
        var inventorySearchDto = new InventorySearchDto(req.Id, req.StoreId,req.Name,req.IsActive);
        return await _inventoryRepository.InventoryGetAllAsync(inventorySearchDto,cancellationToken);
    }
}