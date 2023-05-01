using Application.Dto.Base;
using Application.Dto.Product;
using MediatR;
namespace Application.Features.Product.Query.ProductGetAll;
public class ProductGetAllQuery:ProductSearchDto,IRequest<PaginationDto<ProductDto>>
{
    
}