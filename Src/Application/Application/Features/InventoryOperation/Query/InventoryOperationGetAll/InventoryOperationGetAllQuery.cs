using Application.Dto.Base;
using Application.Dto.InventoryOperation;
using Application.Dto.Store;
using MediatR;

namespace Application.Features.InventoryOperation.Query.InventoryOperationGetAll;
public class InventoryOperationGetAllQuery:InventoryOperationSearchDto,IRequest<PaginationDto<InventoryOperationDto>>
{
}