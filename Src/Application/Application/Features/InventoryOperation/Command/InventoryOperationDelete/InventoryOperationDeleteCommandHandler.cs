using Application.Common.Enums;
using Application.Common.Messages;
using Application.Dto.InventoryOperation;
using Application.IContracts.IRepository;
using Domain.Enums;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.InventoryOperation.Command.InventoryOperationDelete;
public class InventoryOperationDeleteCommandHandler:IRequestHandler<InventoryOperationDeleteCommand,bool>
{
    #region CtorAndInjection
    private readonly IInventoryOperationRepository _inventoryOperationRepository;
    private readonly IProductRepository _productRepository;
    public InventoryOperationDeleteCommandHandler(IInventoryOperationRepository inventoryOperationRepository, IProductRepository productRepository)
    {
        _inventoryOperationRepository = inventoryOperationRepository;
        _productRepository = productRepository;
    }
    #endregion
    public async Task<bool> Handle(InventoryOperationDeleteCommand req, CancellationToken cancellationToken)
    {
      var check= await _inventoryOperationRepository.InventoryOperationExistAsync(req.Id,cancellationToken);

      var inventoryOperationSearchDto = new InventoryOperationSearchDto(
          req.Id,1,1000,0,-1,InventoryOperationType.NotImportant,new Guid("00000000-0000-0000-0000-000000000000")
          ,new Guid("00000000-0000-0000-0000-000000000000"),SortType.Desc,new Guid("00000000-0000-0000-0000-000000000000"));
      var operationDto = await _inventoryOperationRepository.InventoryOperationGetAllAsync(inventoryOperationSearchDto, cancellationToken);

      await _productRepository.ProductChangeCountDeleteOperationAsync(operationDto.Data.FirstOrDefault(),cancellationToken);
        
      if(check) return await _inventoryOperationRepository.InventoryOperationDeleteAsync(req.Id,cancellationToken);
      throw new BadRequestEntityException(ApplicationMessages.InventoryOperationFailedDeleteOnHandle);
    }
}