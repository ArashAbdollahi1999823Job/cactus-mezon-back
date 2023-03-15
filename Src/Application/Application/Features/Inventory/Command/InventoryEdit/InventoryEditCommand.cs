using Application.Dto.Inventory;
using MediatR;

namespace Application.Features.Inventory.Command.InventoryEdit;
public class InventoryEditCommand:InventoryEditDto,IRequest<bool>
{
}