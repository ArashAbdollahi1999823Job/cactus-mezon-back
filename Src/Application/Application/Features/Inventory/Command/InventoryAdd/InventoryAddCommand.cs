using Application.Dto.Inventory;
using MediatR;

namespace Application.Features.Inventory.Command.InventoryAdd;

public class InventoryAddCommand:InventoryAddDto,IRequest<bool>
{
    
}