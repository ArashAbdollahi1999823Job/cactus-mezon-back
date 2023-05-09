using Application.Dto.UserPicture;
using MediatR;

namespace Application.Features.UserPicture.Query.UserPictureGetAll;
public class UserPictureGetAllQuery:UserPictureSearchDto,IRequest<UserPictureDto>
{

}