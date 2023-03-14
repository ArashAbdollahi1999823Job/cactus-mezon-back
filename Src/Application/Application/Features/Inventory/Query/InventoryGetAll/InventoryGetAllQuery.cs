using Application.Dto.Inventory;
using MediatR;

namespace Application.Features.Inventory.Query.InventoryGetAll;

public class InventoryGetAllQuery:InventorySearchDto,IRequest<IEnumerable<InventoryDto>>
{
    
}