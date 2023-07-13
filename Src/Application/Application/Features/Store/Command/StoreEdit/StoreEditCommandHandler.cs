using Application.Common.Messages;
using Application.Dto.Store;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;
namespace Application.Features.Store.Command.StoreEdit;
public class StoreEditCommandHandler:IRequestHandler<StoreEditCommand,bool>
{
    #region CtorAndInjection
    private readonly IStoreRepository _storeRepository;
    public StoreEditCommandHandler(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }
    #endregion
    public async Task<bool> Handle(StoreEditCommand req, CancellationToken cancellationToken)
    {
        var check =await _storeRepository.StoreExistAsync(req.Id, cancellationToken);
        if (check)
        {
            var shopEditDto = new StoreEditDto(req.Id, req.Name, req.Address, req.PhoneNumber, req.MobileNumber, req.Description, req.UserId,req.IsActive,req.Slug);
            return await _storeRepository.StoreEditAsync(shopEditDto,cancellationToken);
        }
        throw new BadRequestEntityException(ApplicationMessages.StoreFailedEditOnHandle);
    }
}