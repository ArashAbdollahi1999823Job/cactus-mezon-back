using Application.Dto.ProductItem;
using MediatR;

namespace Application.Features.ProductItem.Command.ProductItemAdd;
public class ProductItemAddCommand:ProductItemAddDto,IRequest<bool>
{
 
}