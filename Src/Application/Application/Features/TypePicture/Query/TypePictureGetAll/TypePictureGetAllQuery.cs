using Application.Dto.TypePicture;
using MediatR;

namespace Application.Features.TypePicture.Query.TypePictureGetAll;
public class TypePictureGetAllQuery:TypePictureSearchDto,IRequest<List<TypePictureDto>>
{

}