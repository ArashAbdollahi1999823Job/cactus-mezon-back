using Application.Dto.ProductPicture;
using MediatR;

namespace Application.Features.ProductPicture.Query.ProductPictureGetAll;
public class ProductPictureGetAllQuery:ProductPictureSearchDto,IRequest<List<ProductPictureDto>>
{

}