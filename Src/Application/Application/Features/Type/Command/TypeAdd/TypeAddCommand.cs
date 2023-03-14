using Application.Dto.Type;
using MediatR;
namespace Application.Features.Type.Command.TypeAdd;
public class TypeAddCommand:TypeAddDto,IRequest<bool>
{
}