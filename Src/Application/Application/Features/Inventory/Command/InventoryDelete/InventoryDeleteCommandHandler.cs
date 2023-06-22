using Application.Common.Enums;
using Application.Common.Messages;
using Application.Dto.Product;
using Application.Enums;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Inventory.Command.InventoryDelete;
public class InventoryDeleteCommandHandler:IRequestHandler<InventoryDeleteCommand,bool>
{
    #region CtorAndInjection
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IProductRepository _productRepository;
    public InventoryDeleteCommandHandler(IInventoryRepository inventoryRepository, IProductRepository productRepository)
    {
        _inventoryRepository = inventoryRepository;
        _productRepository = productRepository;
    }
    #endregion
    public async Task<bool> Handle(InventoryDeleteCommand req, CancellationToken cancellationToken)
    {
        var productSearchDto = new ProductSearchDto(
            1, 1000, new Guid("00000000-0000-0000-0000-000000000000"), ActiveType.NotImportant,
            null, null, 0, req.Id, new Guid("00000000-0000-0000-0000-000000000000"),
            new Guid("00000000-0000-0000-0000-000000000000"), -1, SortType.Desc,
            new Guid("00000000-0000-0000-0000-000000000000"), false);
        var products = await _productRepository.ProductGetAllAsync(productSearchDto, cancellationToken);

        if (products.Data.Any())
            throw new BadRequestEntityException(ApplicationMessages.InventoryFailedDeleteHasProduct +
                                                products.Data.Count());
        
        var check= await _inventoryRepository.InventoryExistAsync(req.Id,cancellationToken);
        if(check) return await _inventoryRepository.InventoryDeleteAsync(req.Id,cancellationToken);
        throw new BadRequestEntityException(ApplicationMessages.InventoryFailedDeleteOnHandle);
    }
}