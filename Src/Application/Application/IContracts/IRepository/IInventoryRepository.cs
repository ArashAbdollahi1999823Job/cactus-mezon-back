using Application.Dto.Inventory;
using Domain.Entities.InventoryEntity;

namespace Application.IContracts.IRepository;
public interface IInventoryRepository
{
    public Task<bool> InventoryAddAsync(InventoryAddDto inventoryAddDto,CancellationToken cancellationToken);
    public Task<IEnumerable<InventoryDto>> InventoryGetAllAsync(InventorySearchDto inventorySearchDto,CancellationToken cancellationToken);
    public Task<Inventory> InventoryGetByIdAsync(Guid id,CancellationToken cancellationToken);
    public Task<bool> InventoryDeleteAsync(Guid id,CancellationToken cancellationToken);
    public Task<bool> InventoryEditAsync(InventoryEditDto inventoryEditDto,CancellationToken cancellationToken);
    public Task<bool> InventoryExistAsync(Guid id, CancellationToken cancellationToken);
}