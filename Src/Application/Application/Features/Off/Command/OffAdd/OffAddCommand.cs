using Application.Dto.Off;
using MediatR;
namespace Application.Features.Off.Command.OffAdd;
public class OffAddCommand:OffAddDto,IRequest<bool>
{
    
}