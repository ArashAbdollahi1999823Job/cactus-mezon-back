#region UsingAndNamespace
using Application.Dto.Base;
using Application.Dto.Store;
using Domain.Entities.StoreEntity;
namespace Application.IContracts.IRepository;
#endregion
public interface IStoreRepository
{
    public Task<PaginationDto<StoreDto>> StoreGetAllAsync(StoreSearchDto storeSearchDto,CancellationToken cancellationToken);
    public Task<Store> StoreGetByIdAsync(Guid id,CancellationToken cancellationToken);
    public Task<bool> StoreDeleteAsync(Guid id,CancellationToken cancellationToken);
    public Task<bool> StoreEditAsync(StoreEditDto shopEditDto,CancellationToken cancellationToken);
    public Task<bool> StoreAddAsync(StoreAddDto shopAddDto,CancellationToken cancellationToken);
    public Task<bool> StoreExistAsync(Guid id, CancellationToken cancellationToken);
}