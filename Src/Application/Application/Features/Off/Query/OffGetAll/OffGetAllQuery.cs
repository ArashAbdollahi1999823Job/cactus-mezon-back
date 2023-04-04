using Application.Dto.Base;
using Application.Dto.Brand;
using Application.Dto.Off;
using MediatR;

namespace Application.Features.Off.Query.OffGetAll;
public class OffGetAllQuery:OffSearchDto,IRequest<List<OffDto>>
{
    
}