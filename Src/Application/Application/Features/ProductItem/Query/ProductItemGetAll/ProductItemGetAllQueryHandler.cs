using Application.Dto.ProductItem;
using Application.IContracts.IRepository;
using MediatR;

namespace Application.Features.ProductItem.Query.ProductItemGetAll;
public class ProductItemGetAllQueryHandler:IRequestHandler<ProductItemGetAllQuery,List<ProductItemDto>>
{
    #region CtorAndInjection
    private readonly IProductItemRepository _productItemRepository;
    public ProductItemGetAllQueryHandler(IProductItemRepository productItemRepository)
    {
        _productItemRepository = productItemRepository;
    }
    #endregion
    public async Task<List<ProductItemDto>> Handle(ProductItemGetAllQuery req, CancellationToken cancellationToken)
    {
        ProductItemSearchDto productItemSearchDto = new ProductItemSearchDto(req.Id, req.ProductId);
        return await _productItemRepository.ProductItemGetAllAsync(productItemSearchDto, cancellationToken);
    }
}