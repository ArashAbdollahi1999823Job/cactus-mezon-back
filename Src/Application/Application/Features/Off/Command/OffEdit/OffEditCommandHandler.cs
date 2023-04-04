using Application.Common.Messages;
using Application.Dto.Brand;
using Application.Dto.Off;
using Application.Features.Brand.Command.BrandEdit;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;
namespace Application.Features.Off.Command.OffEdit;
public class OffEditCommandHandler:IRequestHandler<OffEditCommand,bool>
{
    #region CtorAndInjection
    private readonly IOffRepository _offRepository;
    public OffEditCommandHandler(IOffRepository offRepository)
    {
        _offRepository = offRepository;
    }
    #endregion
    public async Task<bool> Handle(OffEditCommand req, CancellationToken cancellationToken)
    {
        var check =await _offRepository.OffExistAsync(req.Id,cancellationToken);
        if (check)
        {
            var offEditDto = new OffEditDto(req.Id,req.Name, req.Description,req.OffPercent,req.StartDate,req.EndDate);
            return await _offRepository.OffEditAsync(offEditDto, cancellationToken);
        }

        throw new BadRequestEntityException(ApplicationMessages.OffEditFailedOnHandle);
    }
}