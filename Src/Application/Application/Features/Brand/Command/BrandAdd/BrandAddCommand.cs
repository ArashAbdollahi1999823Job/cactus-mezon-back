using Application.Dto.Brand;
using MediatR;

namespace Application.Features.Brand.Command.BrandAdd;
public class BrandAddCommand:BrandAddDto,IRequest<bool>
{
    
}