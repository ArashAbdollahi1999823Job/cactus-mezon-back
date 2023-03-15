using Application.Dto.Inventory;
using Domain.Entities.InventoryEntity;

namespace Application.IContracts.IRepository;
public interface IInventoryRepository
{
    public Task<bool> InventoryAddAsync(InventoryAddDto inventoryAddDto,CancellationToken cancellationToken);
    public Task<IEnumerable<InventoryDto>> InventoryGetAllAsync(InventorySearchDto inventorySearchDto,CancellationToken cancellationToken);
    public Task<Inventory> InventoryGetByIdAsync(long id,CancellationToken cancellationToken);
    public Task<bool> InventoryDeleteAsync(long id,CancellationToken cancellationToken);
    public Task<bool> InventoryEditAsync(InventoryEditDto inventoryEditDto,CancellationToken cancellationToken);
    public Task<bool> InventoryExistAsync(long id, CancellationToken cancellationToken);
}