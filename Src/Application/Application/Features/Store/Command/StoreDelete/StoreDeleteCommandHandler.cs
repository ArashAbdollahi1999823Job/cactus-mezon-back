using Application.Common.Messages;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;
namespace Application.Features.Store.Command.StoreDelete;
public class StoreDeleteCommandHandler:IRequestHandler<StoreDeleteCommand,bool>
{
    #region CtorAndInjection
    private readonly IStoreRepository _storeRepository;
    public StoreDeleteCommandHandler(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }
    #endregion
    public async Task<bool> Handle(StoreDeleteCommand req, CancellationToken cancellationToken)
    {
      var check= await _storeRepository.StoreExistAsync(req.Id,cancellationToken);
      if(check) return await _storeRepository.StoreDeleteAsync(req.Id,cancellationToken);
      throw new BadRequestEntityException(ApplicationMessages.StoreFailedDeleteOnHandle);
    }
}