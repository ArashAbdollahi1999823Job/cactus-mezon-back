#region UsingAndNamespace
using MediatR;
namespace Application.Features.Store.Command.StoreDelete;
#endregion
public class StoreDeleteCommand:IRequest<bool>
{
    public StoreDeleteCommand(long id)
    {
        Id = id;
    }
    public long Id { get; }
}