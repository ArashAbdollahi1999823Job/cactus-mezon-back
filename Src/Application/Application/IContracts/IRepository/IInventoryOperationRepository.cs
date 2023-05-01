using Application.Dto.Base;
using Application.Dto.InventoryOperation;
using Application.Dto.Store;
using Domain.Entities.InventoryEntity;
using Domain.Entities.StoreEntity;
using StoreSearchDto = Application.Dto.Store.StoreSearchDto;
namespace Application.IContracts.IRepository;
public interface IInventoryOperationRepository
{
    public Task<PaginationDto<InventoryOperationDto>> InventoryOperationGetAllAsync(InventoryOperationSearchDto inventoryOperationSearchDto,CancellationToken cancellationToken);
    public Task<bool> InventoryOperationDeleteAsync(Guid id,CancellationToken cancellationToken);
    public Task<bool> InventoryOperationAddAsync(InventoryOperationAddDto inventoryOperationAddDto,CancellationToken cancellationToken);
    public Task<bool> InventoryOperationExistAsync(Guid id, CancellationToken cancellationToken);
}