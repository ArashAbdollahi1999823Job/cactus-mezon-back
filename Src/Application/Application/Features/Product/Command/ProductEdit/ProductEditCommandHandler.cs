using Application.Common.Messages;
using Application.Dto.Product;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;
namespace Application.Features.Product.Command.ProductEdit;
public class ProductEditCommandHandler:IRequestHandler<ProductEditCommand,bool>
{
    #region CtorAndInjection
    private readonly IProductRepository _productRepository;
    public ProductEditCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    #endregion
    public async Task<bool> Handle(ProductEditCommand req, CancellationToken cancellationToken)
    {
        var check =await _productRepository.ProductExistAsync(req.Id,cancellationToken);
        if (check)
        {
            var productEditDto = new ProductEditDto(req.Name, req.Slug, req.Description, req.MetaDescription, req.Price,
                req.Summary, req.Id, req.IsActive, req.BrandId, req.TypeId, req.InventoryId,req.OffId);
            return await _productRepository.ProductEditAsync(productEditDto, cancellationToken);
        }

        throw new BadRequestEntityException(ApplicationMessages.ProductEditFailedOnHandle);
    }
}