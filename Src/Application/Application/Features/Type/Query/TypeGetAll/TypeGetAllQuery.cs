using Application.Dto.Base;
using Application.Dto.Type;
using MediatR;
namespace Application.Features.Type.Query.TypeGetAll;
public class TypeGetAllQuery:TypeSearchDto,IRequest<PaginationDto<TypeDto>>
{
}
