using Application.Dto.TypePicture;
using MediatR;
namespace Application.Features.TypePicture.Command.TypePictureAdd;
public class TypePictureAddCommand:TypePictureAddDto,IRequest<bool>
{
 
}