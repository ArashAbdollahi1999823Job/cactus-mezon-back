using Application.Common.Enums;
using Application.Common.Helpers;
using Application.Dto.Product;
using Application.Enums;
using Application.IContracts.IRepository;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Product.Command.ProductAdd;

public class ProductAddCommandHandler : IRequestHandler<ProductAddCommand, bool>
{
    #region CtorAndInjection

    private readonly IProductRepository _productRepository;
    private readonly ISiteMapService _siteMapService;
    private readonly IConfiguration _configuration;

    public ProductAddCommandHandler(IProductRepository productRepository, ISiteMapService siteMapService,
        IConfiguration configuration)
    {
        _productRepository = productRepository;
        _siteMapService = siteMapService;
        _configuration = configuration;
    }

    #endregion

    public async Task<bool> Handle(ProductAddCommand req, CancellationToken cancellationToken)
    {
        #region CreateProduct
        var productAddDto = new ProductAddDto(req.Name, req.Slug, req.Description, req.MetaDescription, req.Price,
            req.Summary, req.BrandId, req.TypeId, req.InventoryId);
        var checkAdd = await _productRepository.ProductAddAsync(productAddDto, cancellationToken);
       
        #endregion

        if (checkAdd)
        {
            var productSearchDto = new ProductSearchDto(1, 1000, new Guid("00000000-0000-0000-0000-000000000000"),
                ActiveType.NotImportant, null, req.Slug, 0, new Guid("00000000-0000-0000-0000-000000000000"),
                new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), -1, SortType.Desc,
                new Guid("00000000-0000-0000-0000-000000000000"), false);
            var product =  _productRepository.ProductGetAllAsync(productSearchDto, cancellationToken).Result.Data.FirstOrDefault();
            var domainUrl = _configuration["Url:BackendUrl:Production"];
            _siteMapService.UpdateSiteMap(domainUrl+product.TypeSlug+"/"+product.Slug,"add","daily","0.8");
        }

        return checkAdd;
    }
}