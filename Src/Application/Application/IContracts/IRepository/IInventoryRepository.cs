using Application.Dto.Inventory;

namespace Application.IContracts.IRepository;
public interface IInventoryRepository
{
    public Task<bool> InventoryAddAsync(InventoryAddDto inventoryAddDto,CancellationToken cancellationToken);
    public Task<IEnumerable<InventoryDto>> InventoryGetAllAsync(InventorySearchDto inventorySearchDto,CancellationToken cancellationToken);
}