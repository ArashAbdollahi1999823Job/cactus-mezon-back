using Application.Common.Messages;
using Application.Dto.InventoryOperation;
using Application.Dto.Store;
using Application.Features.Store.Command.StoreAdd;
using Application.IContracts.IRepository;
using Domain.Enums;
using Domain.Exceptions;
using MediatR;
namespace Application.Features.InventoryOperation.Command.InventoryOperationAdd;
public class InventoryOperationAddCommandHandler:IRequestHandler<InventoryOperationAddCommand,bool>
{
    #region CtorAndInjection
    private readonly IInventoryOperationRepository _inventoryOperationRepository;
    private readonly IProductRepository _productRepository;
    public InventoryOperationAddCommandHandler(IInventoryOperationRepository inventoryOperationRepository, IProductRepository productRepository)
    {
        _inventoryOperationRepository = inventoryOperationRepository;
        _productRepository = productRepository;
    }
    #endregion
    public async Task<bool> Handle(InventoryOperationAddCommand req, CancellationToken cancellationToken)
    {

        if (await _productRepository.ProductChangeCountAsync(req.Count,req.InventoryOperationType, req.ProductId, cancellationToken))
        {
            var inventoryOperationAddDto = new InventoryOperationAddDto(req.Description,req.Price,req.Count,req.InventoryOperationType,req.ProductId);
            return await _inventoryOperationRepository.InventoryOperationAddAsync(inventoryOperationAddDto,cancellationToken);
        }
        throw new BadRequestEntityException(ApplicationMessages.StoreFailedAddOnHandle);
    }
}