using Application.Common.Messages;
using Application.Features.Brand.Command.BrandDelete;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;
namespace Application.Features.Off.Command.OffDelete;
public class OffDeleteCommandHandler:IRequestHandler<OffDeleteCommand,bool>
{
    #region CtorAndInjection
    private readonly IOffRepository _offRepository;
    public OffDeleteCommandHandler(IOffRepository offRepository)
    {
        _offRepository = offRepository;
    }
    #endregion
    public async Task<bool> Handle(OffDeleteCommand req, CancellationToken cancellationToken)
    {
        var check= await _offRepository.OffExistAsync(req.Id,cancellationToken);
        if(check) return await _offRepository.OffDeleteAsync(req.Id,cancellationToken);
        throw new BadRequestEntityException(ApplicationMessages.OffFailedDeleteOnHandle);
    }
}