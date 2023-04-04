using Application.Common.Messages;
using Application.Dto.Brand;
using Application.Dto.Off;
using Application.Features.Brand.Command.BrandAdd;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;
namespace Application.Features.Off.Command.OffAdd;
public class OffAddCommandHandler : IRequestHandler<OffAddCommand, bool>
{
    #region CtorAndInjection
    private readonly IOffRepository _offRepository;
    public OffAddCommandHandler(IOffRepository offRepository)
    {
        _offRepository = offRepository;
    }
    #endregion

    public async Task<bool> Handle(OffAddCommand req, CancellationToken cancellationToken)
    {
        var offAddDto = new OffAddDto(req.Name, req.Description, req.OffPercent, req.StartDate,req.EndDate,req.StoreId);
      return  await _offRepository.OffAddAsync(offAddDto, cancellationToken);
      throw new BadRequestEntityException(ApplicationMessages.OffAddFailedOnHandle);
    }
}