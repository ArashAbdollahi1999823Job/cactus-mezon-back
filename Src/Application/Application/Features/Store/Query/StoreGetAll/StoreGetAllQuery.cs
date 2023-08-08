using Application.Dto.Base;
using Application.Dto.Store;
using Application.IContracts.IBehaviourPipe;
using MediatR;
namespace Application.Features.Store.Query.StoreGetAll;
public class StoreGetAllQuery:StoreSearchDto,IRequest<PaginationDto<StoreDto>>,IBehavioursCacheQuery
{
    public int MinutesCache { get; set; } = 0;
}