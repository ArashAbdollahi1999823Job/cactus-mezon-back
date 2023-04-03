using Application.Dto.Base;
using Application.Dto.Product;
using Application.Dto.ProductDto;
using Application.IContracts.IRepository;
using MediatR;
namespace Application.Features.Product.Query.ProductGetAll;
public class ProductGetAllQueryHandler:IRequestHandler<ProductGetAllQuery,PaginationDto<ProductDto>>
{
    #region CtorAndInjection
    private readonly IProductRepository _productRepository;
    public ProductGetAllQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    #endregion
    public async Task<PaginationDto<ProductDto>> Handle(ProductGetAllQuery req, CancellationToken cancellationToken)
    {
        var productSearchDto = new ProductSearchDto(req.PageIndex, req.PageSize, req.Id, req.IsActive, req.Name,
            req.Slug, req.Price, req.InventoryId, req.TypeId, req.BrandId, req.Off, req.SortType,req.StoreId);
        return await _productRepository.ProductGetAllAsync(productSearchDto, cancellationToken);
    }
}