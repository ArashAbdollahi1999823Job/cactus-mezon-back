using MediatR;

namespace Application.Features.Off.Command.OffDelete;
public class OffDeleteCommand:IRequest<bool>
{
    public Guid Id { set; get; }

    public OffDeleteCommand(Guid id)
    {
        Id = id;
    }
}