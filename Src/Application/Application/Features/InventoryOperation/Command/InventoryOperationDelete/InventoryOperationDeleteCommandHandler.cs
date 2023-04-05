using Application.Common.Messages;
using Application.Features.Store.Command.StoreDelete;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.InventoryOperation.Command.InventoryOperationDelete;
public class InventoryOperationDeleteCommandHandler:IRequestHandler<InventoryOperationDeleteCommand,bool>
{
    #region CtorAndInjection
    private readonly IInventoryOperationRepository _inventoryOperationRepository;
    public InventoryOperationDeleteCommandHandler(IInventoryOperationRepository inventoryOperationRepository)
    {
        _inventoryOperationRepository = inventoryOperationRepository;
    }
    #endregion
    public async Task<bool> Handle(InventoryOperationDeleteCommand req, CancellationToken cancellationToken)
    {
      var check= await _inventoryOperationRepository.InventoryOperationExistAsync(req.Id,cancellationToken);
      if(check) return await _inventoryOperationRepository.InventoryOperationDeleteAsync(req.Id,cancellationToken);
      throw new BadRequestEntityException(ApplicationMessages.InventoryOperationFailedDeleteOnHandle);
    }
}