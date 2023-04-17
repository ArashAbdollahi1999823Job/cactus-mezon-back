using Application.Dto.TypeItem;
using MediatR;

namespace Application.Features.TypeItem.Command.TypeItemAdd;
public class TypeItemAddCommand:TypeItemAddDto,IRequest<bool>
{
 
}