using Application.Dto.ProductPicture;
using MediatR;

namespace Application.Features.ProductPicture.Command.ProductPictureEdit;

public class ProductPictureEditCommand:ProductPictureEditDto,IRequest<bool>
{

}