#region UsignAndNamespace

using Application.Dto.Product;
using Application.Dto.ProductDto;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.ProductEntity;
using Microsoft.Extensions.Configuration;

namespace Application.Common.AutoMapping.Resolvers;
#endregion

public class ProductPictureThumbnailResolver:IValueResolver<Product,ProductDto,string>
{
    #region CtorAndInjection
    private readonly IConfiguration _configuration;
    public ProductPictureThumbnailResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    #endregion
    public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
    {
       // if (!string.IsNullOrWhiteSpace(source.PictureThumbnailUrl))return _configuration["BackendUrl"]+ _configuration["LocationUrl:ProductPictureThumbnailUrl"]+source.Title+"/"+ source.PictureThumbnailUrl;
        return null;
    }
}

