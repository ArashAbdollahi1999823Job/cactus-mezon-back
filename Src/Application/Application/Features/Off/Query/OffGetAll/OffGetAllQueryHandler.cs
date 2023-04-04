using Application.Dto.Off;
using Application.IContracts.IRepository;
using MediatR;

namespace Application.Features.Off.Query.OffGetAll;
public class OffGetAllQueryHandler:IRequestHandler<OffGetAllQuery,List<OffDto>>
{
    #region CtorAndInjection
    private readonly IOffRepository _offRepository;
    public OffGetAllQueryHandler(IOffRepository offRepository)
    {
        _offRepository = offRepository;
    }
    #endregion
    public async Task<List<OffDto>> Handle(OffGetAllQuery req, CancellationToken cancellationToken)
    {
        var offSearchDto = new OffSearchDto(req.Id,req.StoreId);
        return await _offRepository.OffGetAllAsync(offSearchDto, cancellationToken);
    }
}