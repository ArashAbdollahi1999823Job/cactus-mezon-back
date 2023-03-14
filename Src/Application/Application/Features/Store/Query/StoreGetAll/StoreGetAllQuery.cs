using Application.Dto.Base;
using Application.Dto.Store;
using MediatR;
namespace Application.Features.Store.Query.StoreGetAll;
public class StoreGetAllQuery:StoreSearchDto,IRequest<PaginationDto<StoreDto>>
{
}