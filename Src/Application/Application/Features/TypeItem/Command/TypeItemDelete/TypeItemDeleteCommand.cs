using MediatR;

namespace Application.Features.TypeItem.Command.TypeItemDelete;

public class TypeItemDeleteCommand:IRequest<bool>
{
    public Guid Id { get; set; }

    public TypeItemDeleteCommand(Guid id)
    {
        Id = id;
    }
}