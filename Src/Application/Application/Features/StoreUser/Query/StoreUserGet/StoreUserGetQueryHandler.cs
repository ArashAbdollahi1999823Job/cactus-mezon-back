using Application.Dto.StoreUser;
using Application.IContracts.IRepository;
using MediatR;
namespace Application.Features.StoreUser.Query.StoreUserGet;
public class StoreUserGetQueryHandler:IRequestHandler<StoreUserGetQuery,StoreUserDto>
{
    #region CtoreAndInjection
    private readonly IStoreUserRepository _storeUserRepository;
    public StoreUserGetQueryHandler(IStoreUserRepository storeUserRepository)
    {
        _storeUserRepository = storeUserRepository;
    }
    #endregion
    
    
    public Task<StoreUserDto> Handle(StoreUserGetQuery req, CancellationToken cancellationToken)
    {
        StoreUserSearchDto storeUserSearchDto = new StoreUserSearchDto(req.Id,req.UserId);
        return _storeUserRepository.StoreUserGetAsync(storeUserSearchDto, cancellationToken);
    }
}