﻿#region UsingAndNamespace

using Application.Dto.Product;
using MediatR;
namespace Application.Features.Products.Queries.GetProductBySlug;
#endregion
public class GetProductBySlugQuery:IRequest<ProductDto>
{
    public string Slug { get; set; }

    public GetProductBySlugQuery(string slug)
    {
        Slug = slug;
    }
}