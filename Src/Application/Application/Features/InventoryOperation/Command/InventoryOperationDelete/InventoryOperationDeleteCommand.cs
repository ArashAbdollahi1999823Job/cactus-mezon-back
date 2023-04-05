using MediatR;
namespace Application.Features.InventoryOperation.Command.InventoryOperationDelete;
public class InventoryOperationDeleteCommand:IRequest<bool>
{
    public InventoryOperationDeleteCommand(long id)
    {
        Id = id;
    }
    public long Id { get; }
}