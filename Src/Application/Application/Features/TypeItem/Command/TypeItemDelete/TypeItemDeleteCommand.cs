using MediatR;

namespace Application.Features.TypeItem.Command.TypeItemDelete;

public class TypeItemDeleteCommand:IRequest<bool>
{
    public long Id { get; set; }

    public TypeItemDeleteCommand(long id)
    {
        Id = id;
    }
}