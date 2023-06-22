using Application.Common.Enums;
using Application.Common.Messages;
using Application.Dto.Color;
using Application.Dto.InventoryOperation;
using Application.Dto.ProductItem;
using Application.Dto.ProductPicture;
using Application.IContracts.IRepository;
using Application.IContracts.IServices;
using Domain.Enums;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Product.Command.ProductDelete;

public class ProductDeleteCommandHandler:IRequestHandler<ProductDeleteCommand,bool>
{
    #region CtorAndInjection
    private readonly IProductRepository _productRepository;
    private readonly IProductPictureRepository _productPictureRepository;
    private readonly IFileUploader _fileUploader;
    private readonly IInventoryOperationRepository _inventoryOperationRepository;
    private readonly IColorRepository _colorRepository;
    private readonly IProductItemRepository _productItemRepository;
    public ProductDeleteCommandHandler(IProductRepository productRepository, IProductPictureRepository productPictureRepository, IFileUploader fileUploader, IInventoryOperationRepository inventoryOperationRepository, IColorRepository colorRepository, IProductItemRepository productItemRepository)
    {
        _productRepository = productRepository;
        _productPictureRepository = productPictureRepository;
        _fileUploader = fileUploader;
        _inventoryOperationRepository = inventoryOperationRepository;
        _colorRepository = colorRepository;
        _productItemRepository = productItemRepository;
    }
    #endregion
    public async Task<bool> Handle(ProductDeleteCommand req, CancellationToken cancellationToken)
    {
        var check= await _productRepository.ProductExistAsync(req.Id,cancellationToken);
        
        var productPictureSearchDto = new ProductPictureSearchDto(new Guid("00000000-0000-0000-0000-000000000000"), req.Id, 1, 0, 100);
        var productPictures = await _productPictureRepository.ProductPictureGetAllAsync(productPictureSearchDto,cancellationToken);

        var inventoryOperationSearchDto = new InventoryOperationSearchDto(
            new Guid("00000000-0000-0000-0000-000000000000"), 1, 1000, 0, -1, InventoryOperationType.NotImportant,
            req.Id, new Guid("00000000-0000-0000-0000-000000000000"), SortType.Desc,
            new Guid("00000000-0000-0000-0000-000000000000"));
        var inventoryOperation =
            await _inventoryOperationRepository.InventoryOperationGetAllAsync(inventoryOperationSearchDto,
                cancellationToken);

        var colors = await _colorRepository.ColorGetAllAsync(
            new ColorSearchDto(new Guid("00000000-0000-0000-0000-000000000000"), req.Id), cancellationToken);

        var items = await _productItemRepository.ProductItemGetAllAsync(
            new ProductItemSearchDto(new Guid("00000000-0000-0000-0000-000000000000"), req.Id), cancellationToken);
        
        items.ForEach(x =>
        {
            _productItemRepository.ProductItemDeleteAsync(x.Id, cancellationToken);
        });
        
        colors.ForEach(x =>
        {
            _colorRepository.ColorDeleteAsync(x.Id, cancellationToken);
        });
        
        foreach (var inventoryOperationDto in inventoryOperation.Data)
        {
            await _inventoryOperationRepository.InventoryOperationDeleteAsync(inventoryOperationDto.Id, cancellationToken);
        }
        
        productPictures.ForEach(x =>
        {
            _fileUploader.Delete(x.PictureUrl);
            _productPictureRepository.ProductPictureDeleteAsync(x.Id, cancellationToken);
        });
        
        
        if(check) return await _productRepository.ProductDeleteAsync(req.Id,cancellationToken);
        throw new BadRequestEntityException(ApplicationMessages.ProductFailedDeleteOnHandle);
    }
}