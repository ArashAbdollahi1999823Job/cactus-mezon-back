using Application.Common.Messages;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.ProductItem.Command.ProductItemDelete;
public class ProductItemCommandHandler:IRequestHandler<ProductItemDeleteCommand,bool>
{
    #region CtorAndInjection
    private readonly IProductItemRepository _productItemRepository;
    public ProductItemCommandHandler(IProductItemRepository productItemRepository)
    {
        _productItemRepository = productItemRepository;
    }
    #endregion
    public async Task<bool> Handle(ProductItemDeleteCommand req, CancellationToken cancellationToken)
    {
        var productItem =await _productItemRepository.ProductItemExistAsync(req.Id, cancellationToken);

        if (productItem)
        {
           return await _productItemRepository.ProductItemDeleteAsync(req.Id,cancellationToken);
        }
        throw new BadRequestEntityException(ApplicationMessages.ProductItemFailedDeleteOnHandle);
    }
}