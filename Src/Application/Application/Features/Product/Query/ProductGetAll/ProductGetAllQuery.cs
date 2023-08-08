using Application.Dto.Base;
using Application.Dto.Product;
using Application.IContracts.IBehaviourPipe;
using MediatR;
namespace Application.Features.Product.Query.ProductGetAll;
public class ProductGetAllQuery:ProductSearchDto,IRequest<PaginationDto<ProductDto>>,IBehavioursCacheQuery
{
    public int MinutesCache { get; set; } = 0;
}