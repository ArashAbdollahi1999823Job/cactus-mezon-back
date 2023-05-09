using Application.Dto.UserPicture;
using MediatR;

namespace Application.Features.UserPicture.Command.UserPictureAdd;
public class UserPictureAddCommand:UserPictureAddDto,IRequest<bool>
{
 
}