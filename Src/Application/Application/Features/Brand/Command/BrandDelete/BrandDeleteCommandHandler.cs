using Application.Common.Messages;
using Application.Features.Product.Command.ProductDelete;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;
namespace Application.Features.Brand.Command.BrandDelete;
public class BrandDeleteCommandHandler:IRequestHandler<BrandDeleteCommand,bool>
{
    #region CtorAndInjection
    private readonly IBrandRepository _brandRepository;
    public BrandDeleteCommandHandler(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }
    #endregion
    public async Task<bool> Handle(BrandDeleteCommand req, CancellationToken cancellationToken)
    {
        var check= await _brandRepository.BrandExistAsync(req.Id,cancellationToken);
        if(check) return await _brandRepository.BrandDeleteAsync(req.Id,cancellationToken);
        throw new BadRequestEntityException(ApplicationMessages.BrandFailedDeleteOnHandle);
    }
}