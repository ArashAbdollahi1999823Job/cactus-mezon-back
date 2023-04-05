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
    /*public Task<InventoryOperation> InventoryOperationGetByIdAsync(long id,CancellationToken cancellationToken);*/
    public Task<bool> InventoryOperationDeleteAsync(long id,CancellationToken cancellationToken);
    /*public Task<bool> InventoryOperationEditAsync(StoreEditDto shopEditDto,CancellationToken cancellationToken);*/
    public Task<bool> InventoryOperationAddAsync(InventoryOperationAddDto inventoryOperationAddDto,CancellationToken cancellationToken);
    public Task<bool> InventoryOperationExistAsync(long id, CancellationToken cancellationToken);
}