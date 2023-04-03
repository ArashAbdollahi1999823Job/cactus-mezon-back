#region UsignAndNamespace

using Application.Dto.Product;
using Application.Dto.ProductDto;
using MediatR;

namespace Application.Features.Products.Queries.GetProductById;
#endregion
public class GetProductByIdQuery:IRequest<ProductDto>
{
    public long Id { get; set; }
    public GetProductByIdQuery(long id)
    {
        Id = id;
    }
}
