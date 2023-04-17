using Application.Common.Messages;
using Application.Dto.ProductItem;
using Application.Features.ProductItem.Command.ProductItemAdd;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.ProductItem.Command.ProductItemAdd;
public class ProductItemAddCommandHandler : IRequestHandler<ProductItemAddCommand, bool>
{
    #region CtorAndInjection
    private readonly IProductItemRepository _productItemRepository;
    public ProductItemAddCommandHandler(IProductItemRepository productItemRepository)
    {
        _productItemRepository = productItemRepository;
    }
    #endregion


    public async Task<bool> Handle(ProductItemAddCommand req, CancellationToken cancellationToken)
    {
  
            ProductItemAddDto productItemAddDto = new ProductItemAddDto(req.Name,req.ProductId,req.Value);
            return await _productItemRepository.ProductItemAddAsync(productItemAddDto,cancellationToken);
            throw new BadRequestEntityException(ApplicationMessages.ProductItemFailedAddOnHandle);
    }
}