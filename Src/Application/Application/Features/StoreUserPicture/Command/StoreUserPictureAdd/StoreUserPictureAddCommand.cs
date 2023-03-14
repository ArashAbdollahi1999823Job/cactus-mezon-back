using Application.Dto.StoreUserPicture;
using MediatR;

namespace Application.Features.StoreUserPicture.Command.StoreUserPictureAdd;
public class StoreUserPictureAddCommand:StoreUserPictureAddDto,IRequest<bool>
{
 
}