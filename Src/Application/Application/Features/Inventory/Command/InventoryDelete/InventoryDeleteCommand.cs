using MediatR;
namespace Application.Features.Inventory.Command.InventoryDelete;
public class InventoryDeleteCommand:IRequest<bool>
{
    public InventoryDeleteCommand(long id)
    {
        Id = id;
    }
    public long Id { get; }
}