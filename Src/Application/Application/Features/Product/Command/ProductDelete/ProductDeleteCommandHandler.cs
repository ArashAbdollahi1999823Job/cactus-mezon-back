using Application.Common.Messages;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;
namespace Application.Features.Product.Command.ProductDelete;

public class ProductDeleteCommandHandler:IRequestHandler<ProductDeleteCommand,bool>
{
    #region CtorAndInjection
    private readonly IProductRepository _productRepository;

    public ProductDeleteCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    #endregion
    public async Task<bool> Handle(ProductDeleteCommand req, CancellationToken cancellationToken)
    {
        var check= await _productRepository.ProductExistAsync(req.Id,cancellationToken);
        if(check) return await _productRepository.ProductDeleteAsync(req.Id,cancellationToken);
        throw new BadRequestEntityException(ApplicationMessages.ProductFailedDeleteOnHandle);
    }
}