using Application.Common.Messages;
using Application.Dto.Product;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Product.Command.ProductAdd;

public class ProductAddCommandHandler : IRequestHandler<ProductAddCommand, bool>
{
    #region CtorAndInjection

    private readonly IProductRepository _productRepository;

    public ProductAddCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    #endregion

    public async Task<bool> Handle(ProductAddCommand req, CancellationToken cancellationToken)
    {
        var productAddDto = new ProductAddDto(req.Name, req.Slug, req.Description, req.MetaDescription, req.Price,
            req.Summary, req.BrandId, req.TypeId, req.InventoryId);
      return  await _productRepository.ProductAddAsync(productAddDto, cancellationToken);
      throw new BadRequestEntityException(ApplicationMessages.ProductAddFailedOnHandle);
    }
}