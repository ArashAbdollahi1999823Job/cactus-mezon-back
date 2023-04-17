using Application.Dto.ProductItem;
using MediatR;

namespace Application.Features.ProductItem.Query.ProductItemGetAll;
public class ProductItemGetAllQuery:ProductItemSearchDto,IRequest<List<ProductItemDto>>
{

}