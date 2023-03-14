using Application.Dto.Type;
using MediatR;
namespace Application.Features.Type.Command.TypeEdit;
public class TypeEditCommand:TypeEditDto, IRequest<bool>
{
}