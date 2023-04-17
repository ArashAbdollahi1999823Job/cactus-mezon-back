using Application.Dto.TypeItem;
using MediatR;

namespace Application.Features.TypeItem.Query.TypeItemGetAll;
public class TypeItemGetAllQuery:TypeItemSearchDto,IRequest<List<TypeItemDto>>
{

}