using MediatR;

namespace Application.Features.Type.Command.TypeDelete;
public class TypeDeleteCommand:IRequest<bool>
{
    public long Id { get; set; }

    public TypeDeleteCommand(long id)
    {
        Id = id;
    }
}