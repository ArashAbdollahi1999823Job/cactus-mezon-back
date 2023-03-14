using Application.Common.Messages;
using Application.Dto.Store;
using Application.Dto.StoreUser;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.StoreUser.Command.StoreUserEdit;
public class StoreUserEditCommandHandler:IRequestHandler<StoreUserEditCommand,bool>
{
    #region CtorAndInjection
    private readonly IStoreUserRepository _storeUserRepository;
    private readonly IStoreRepository _storeRepository;
    public StoreUserEditCommandHandler(IStoreUserRepository storeUserRepository, IStoreRepository storeRepository)
    {
        _storeUserRepository = storeUserRepository;
        _storeRepository = storeRepository;
    }
    #endregion
    public async Task<bool> Handle(StoreUserEditCommand req, CancellationToken cancellationToken)
    {
        var check =await _storeRepository.StoreExistAsync(req.Id, cancellationToken);
        if (check)
        {
            var storeUserEditDto = new StoreUserEditDto(req.Id, req.Name, req.Address, req.PhoneNumber, req.MobileNumber, req.Description);
            return await _storeUserRepository.StoreUserEditAsync(storeUserEditDto,cancellationToken);
        }
        throw new BadRequestEntityException(ApplicationMessages.StoreFailedEditOnHandle);
    }
}