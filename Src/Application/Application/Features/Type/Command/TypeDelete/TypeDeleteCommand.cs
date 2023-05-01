using MediatR;

namespace Application.Features.Type.Command.TypeDelete;
public class TypeDeleteCommand:IRequest<bool>
{
    public Guid Id { get; set; }

    public TypeDeleteCommand(Guid id)
    {
        Id = id;
    }
}