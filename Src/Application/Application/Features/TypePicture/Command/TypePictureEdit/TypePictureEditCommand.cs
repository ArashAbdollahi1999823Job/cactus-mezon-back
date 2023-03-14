using Application.Dto.TypePicture;
using MediatR;

namespace Application.Features.TypePicture.Command.TypePictureEdit;

public class TypePictureEditCommand:TypePictureEditDto,IRequest<bool>
{

}