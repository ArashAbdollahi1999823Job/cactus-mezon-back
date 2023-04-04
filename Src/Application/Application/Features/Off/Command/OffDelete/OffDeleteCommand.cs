using MediatR;

namespace Application.Features.Off.Command.OffDelete;
public class OffDeleteCommand:IRequest<bool>
{
    public long Id { set; get; }

    public OffDeleteCommand(long id)
    {
        Id = id;
    }
}