using Application.Dto.Inventory;
using Application.IContracts.IRepository;
using MediatR;

namespace Application.Features.Inventory.Command.InventoryAdd;

public class InventoryAddCommandHandler:IRequestHandler<InventoryAddCommand,bool>
{
    #region CtorAndInjection
    private readonly IInventoryRepository _inventoryRepository;
    public InventoryAddCommandHandler(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }
    #endregion
    
    public async Task<bool> Handle(InventoryAddCommand req, CancellationToken cancellationToken)
    {
        var inventoryAddDto = new InventoryAddDto(req.Name,req.StoreId);
        return await _inventoryRepository.InventoryAddAsync(inventoryAddDto,cancellationToken);
    }
}