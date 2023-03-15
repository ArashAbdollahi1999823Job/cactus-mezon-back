using Application.Common.Messages;
using Application.Dto.Inventory;
using Application.Dto.Store;
using Application.Features.Store.Command.StoreEdit;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Inventory.Command.InventoryEdit;
public class InventoryEditCommandHandler:IRequestHandler<InventoryEditCommand,bool>
{
    #region CtorAndInjection
    private readonly IInventoryRepository _inventoryRepository;
    public InventoryEditCommandHandler(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }
    #endregion
    public async Task<bool> Handle(InventoryEditCommand req, CancellationToken cancellationToken)
    {
        var check =await _inventoryRepository.InventoryExistAsync(req.Id, cancellationToken);
        if (check)
        {
            var inventoryEditDto = new InventoryEditDto(req.Name,req.Id,req.IsActive);
            return await _inventoryRepository.InventoryEditAsync(inventoryEditDto,cancellationToken);
        }
        throw new BadRequestEntityException(ApplicationMessages.StoreFailedEditOnHandle);
    }
}