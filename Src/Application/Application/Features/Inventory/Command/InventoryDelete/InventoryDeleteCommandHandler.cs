using Application.Common.Messages;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Inventory.Command.InventoryDelete;
public class InventoryDeleteCommandHandler:IRequestHandler<InventoryDeleteCommand,bool>
{
    #region CtorAndInjection
    private readonly IInventoryRepository _inventoryRepository;
    public InventoryDeleteCommandHandler(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }
    #endregion
    public async Task<bool> Handle(InventoryDeleteCommand req, CancellationToken cancellationToken)
    {
        var check= await _inventoryRepository.InventoryExistAsync(req.Id,cancellationToken);
        if(check) return await _inventoryRepository.InventoryDeleteAsync(req.Id,cancellationToken);
        throw new BadRequestEntityException(ApplicationMessages.InventoryFailedDeleteOnHandle);
    }
}