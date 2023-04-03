using Application.Dto.Product;
using Application.Dto.ProductDto;
using MediatR;
namespace Application.Features.Product.Command.ProductAdd;
public class ProductAddCommand:ProductAddDto,IRequest<bool>
{
    
}