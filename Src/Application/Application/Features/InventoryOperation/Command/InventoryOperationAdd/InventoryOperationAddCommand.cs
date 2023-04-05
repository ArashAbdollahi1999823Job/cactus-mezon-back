using Application.Dto.InventoryOperation;
using MediatR;
namespace Application.Features.InventoryOperation.Command.InventoryOperationAdd;
public class InventoryOperationAddCommand:InventoryOperationAddDto,IRequest<bool>
{
}