using Application.Common.Enums;
using Application.Common.Helpers;
using Application.Common.Messages;
using Application.Dto.Product;
using Application.Enums;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Product.Command.ProductDelete;

public class ProductDeleteCommandHandler:IRequestHandler<ProductDeleteCommand,bool>
{
    #region CtorAndInjection
    private readonly IProductRepository _productRepository;
    private readonly ISiteMapService _siteMapService;
    private readonly IConfiguration _configuration;
    public ProductDeleteCommandHandler(IProductRepository productRepository, ISiteMapService siteMapService, IConfiguration configuration)
    {
        _productRepository = productRepository;
        _siteMapService = siteMapService;
        _configuration = configuration;
    }
    #endregion
    public async Task<bool> Handle(ProductDeleteCommand req, CancellationToken cancellationToken)
    {
        var check= await _productRepository.ProductExistAsync(req.Id,cancellationToken);
        if (check)
        {
            #region GetLastProduct
            var productSearchDto = new ProductSearchDto(1, 1000, req.Id,
                ActiveType.NotImportant, null, null, 0, new Guid("00000000-0000-0000-0000-000000000000"),
                new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), -1, SortType.Desc,
                new Guid("00000000-0000-0000-0000-000000000000"), false);
            var product =  _productRepository.ProductGetAllAsync(productSearchDto, cancellationToken).Result.Data.FirstOrDefault();
            #endregion

            #region ProductDelete
            var checkDelete= await _productRepository.ProductDeleteAsync(req.Id,cancellationToken);
            if (!checkDelete) return false;
            #endregion

            #region SiteMapDeleteProduct
            var domainUrl = _configuration["Url:BackendUrl:Production"];
            _siteMapService.UpdateSiteMap(domainUrl+product.TypeSlug+"/"+product.Slug,"delete",null,null);
            #endregion
        }
        return true;
    }
}