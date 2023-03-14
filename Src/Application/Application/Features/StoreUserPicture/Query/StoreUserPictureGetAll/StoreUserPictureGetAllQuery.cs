using Application.Dto.StoreUserPicture;
using MediatR;

namespace Application.Features.StoreUserPicture.Query.StoreUserPictureGetAll;
public class StoreUserPictureGetAllQuery:StoreUserPictureSearchDto,IRequest<List<StoreUserPictureDto>>
{

}