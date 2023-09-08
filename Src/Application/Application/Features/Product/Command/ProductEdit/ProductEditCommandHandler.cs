using Application.Common.Enums;
using Application.Common.Helpers;
using Application.Dto.Product;
using Application.Enums;
using Application.IContracts.IRepository;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Product.Command.ProductEdit;
public class ProductEditCommandHandler:IRequestHandler<ProductEditCommand,bool>
{
    #region CtorAndInjection
    private readonly IProductRepository _productRepository;
    private readonly ISiteMapService _siteMapService;
    private readonly IConfiguration _configuration;
    public ProductEditCommandHandler(IProductRepository productRepository, ISiteMapService siteMapService, IConfiguration configuration)
    {
        _productRepository = productRepository;
        _siteMapService = siteMapService;
        _configuration = configuration;
    }
    #endregion
    public async Task<bool> Handle(ProductEditCommand req, CancellationToken cancellationToken)
    {
        var check =await _productRepository.ProductExistAsync(req.Id,cancellationToken);
        
        if (check)
        {
            #region GetLastProduct
            var productSearchDto = new ProductSearchDto(1, 1000, req.Id,
                ActiveType.NotImportant, null, null, 0, new Guid("00000000-0000-0000-0000-000000000000"),
                new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), -1, SortType.Desc,
                new Guid("00000000-0000-0000-0000-000000000000"), false);
            var product =  _productRepository.ProductGetAllAsync(productSearchDto, cancellationToken).Result.Data.FirstOrDefault();
            #endregion

            #region EditProduct
            var productEditDto = new ProductEditDto(req.Name, req.Slug, req.Description, req.MetaDescription, req.Price,
                req.Summary, req.Id, req.IsActive, req.BrandId, req.TypeId, req.InventoryId,req.OffId);
            var checkEdit= await _productRepository.ProductEditAsync(productEditDto, cancellationToken);
            if (!checkEdit) return false;
            #endregion

            #region EditSiteMap
            var domainUrl = _configuration["Url:BackendUrl:Production"];
            _siteMapService.UpdateSiteMap(domainUrl+product.TypeSlug+"/"+product.Slug,"delete",null,null);
            _siteMapService.UpdateSiteMap(domainUrl+product.TypeSlug+"/"+req.Slug,"add","daily","0.8");
            #endregion
        }
        return true;
    }
}