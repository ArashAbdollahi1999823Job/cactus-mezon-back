using Application.Dto.Product;
using MediatR;
namespace Application.Features.Product.Command.ProductAdd;
public class ProductAddCommand:ProductAddDto,IRequest<bool>
{
    
}