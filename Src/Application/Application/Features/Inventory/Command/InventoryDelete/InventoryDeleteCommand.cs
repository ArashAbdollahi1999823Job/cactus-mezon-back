using MediatR;
namespace Application.Features.Inventory.Command.InventoryDelete;
public class InventoryDeleteCommand:IRequest<bool>
{
    public InventoryDeleteCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; }
}