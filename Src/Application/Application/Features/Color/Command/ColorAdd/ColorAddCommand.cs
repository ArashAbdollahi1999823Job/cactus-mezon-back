using Application.Dto.Color;
using MediatR;

namespace Application.Features.Color.Command.ColorAdd;
public class ColorAddCommand:ColorAddDto,IRequest<bool>
{
 
}