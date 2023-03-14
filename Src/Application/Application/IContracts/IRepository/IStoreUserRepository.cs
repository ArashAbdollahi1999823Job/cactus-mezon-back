using Application.Dto.StoreUser;
namespace Application.IContracts.IRepository;
public interface IStoreUserRepository
{
    public Task<StoreUserDto> StoreUserGetAsync(StoreUserSearchDto storeUserSearchDto,CancellationToken cancellationToken);
    public Task<bool> StoreUserEditAsync(StoreUserEditDto shopUserEditDto,CancellationToken cancellationToken);
}