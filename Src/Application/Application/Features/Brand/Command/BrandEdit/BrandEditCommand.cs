using Application.Dto.Brand;
using MediatR;

namespace Application.Features.Brand.Command.BrandEdit;
public class BrandEditCommand:BrandEditDto,IRequest<bool>
{
    
}