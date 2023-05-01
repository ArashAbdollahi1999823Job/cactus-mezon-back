using MediatR;
namespace Application.Features.InventoryOperation.Command.InventoryOperationDelete;
public class InventoryOperationDeleteCommand:IRequest<bool>
{
    public InventoryOperationDeleteCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; }
}