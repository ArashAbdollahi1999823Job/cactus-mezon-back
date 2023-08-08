using Application.Dto.ProductPicture;
using Application.IContracts.IBehaviourPipe;
using MediatR;

namespace Application.Features.ProductPicture.Query.ProductPictureGetAll;
public class ProductPictureGetAllQuery:ProductPictureSearchDto,IRequest<List<ProductPictureDto>>,IBehavioursCacheQuery
{
    public int MinutesCache { get; set; } = 0;
}