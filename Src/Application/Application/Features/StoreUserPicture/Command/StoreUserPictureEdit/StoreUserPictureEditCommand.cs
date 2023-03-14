using Application.Dto.StoreUserPicture;
using MediatR;

namespace Application.Features.StoreUserPicture.Command.StoreUserPictureEdit;

public class StoreUserPictureEditCommand:StoreUserPictureEditDto,IRequest<bool>
{

}