using Application.Dto.ProductPicture;
using MediatR;

namespace Application.Features.ProductPicture.Command.ProductPictureAdd;
public class ProductPictureAddCommand:ProductPictureAddDto,IRequest<bool>
{
 
}