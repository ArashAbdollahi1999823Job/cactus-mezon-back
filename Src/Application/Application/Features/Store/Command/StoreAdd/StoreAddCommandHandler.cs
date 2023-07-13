using Application.Common.Messages;
using Application.Dto.Store;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;
namespace Application.Features.Store.Command.StoreAdd;
public class StoreAddCommandHandler:IRequestHandler<StoreAddCommand,bool>
{
    #region CtorAndInjection
    private readonly IStoreRepository _storeRepository;
    public StoreAddCommandHandler(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }
    #endregion
    public async Task<bool> Handle(StoreAddCommand req, CancellationToken cancellationToken)
    {
        var storeAddDto = new StoreAddDto(req.Name, req.Address, req.PhoneNumber, req.MobileNumber, req.Description, req.UserId,req.Slug);
        return await _storeRepository.StoreAddAsync(storeAddDto,cancellationToken);
        throw new BadRequestEntityException(ApplicationMessages.StoreFailedAddOnHandle);
    }
}