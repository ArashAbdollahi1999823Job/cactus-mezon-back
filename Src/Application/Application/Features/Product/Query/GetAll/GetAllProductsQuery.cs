#region UsignAndNamespace
using Application.Dto.Base;
using Application.Dto.Product;
using Application.IContracts.IBehaviourPipe;
using MediatR;
namespace Application.Features.Products.Queries.GetAll;
#endregion
public class GetAllProductsQuery:IRequest<PaginationDto<ProductDto>>,IBehavioursCacheQuery
{
    public long? BrandId { get; set; }
    public long? TypeId { get; set; }

    //ToDo
    public int HoursSaveData =>1;
}

