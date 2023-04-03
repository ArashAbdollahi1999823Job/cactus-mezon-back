using Application.Dto.Product;
using MediatR;
namespace Application.Features.Product.Command.ProductEdit;
public class ProductEditCommand:ProductEditDto,IRequest<bool>
{
    
}