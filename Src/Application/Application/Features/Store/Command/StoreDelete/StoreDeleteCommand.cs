using MediatR;
namespace Application.Features.Store.Command.StoreDelete;
public class StoreDeleteCommand:IRequest<bool>
{
    public StoreDeleteCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; }
}