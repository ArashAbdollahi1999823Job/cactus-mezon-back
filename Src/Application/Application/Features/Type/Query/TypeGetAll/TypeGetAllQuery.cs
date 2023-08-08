using Application.Dto.Base;
using Application.Dto.Type;
using Application.IContracts.IBehaviourPipe;
using MediatR;
namespace Application.Features.Type.Query.TypeGetAll;
public class TypeGetAllQuery:TypeSearchDto,IRequest<PaginationDto<TypeDto>>,IBehavioursCacheQuery
{
    public int MinutesCache { get; set; } = 0;
}
