using Application.Dto.Color;
using MediatR;

namespace Application.Features.Color.Query.ColorGetAll;
public class ColorGetAllQuery:ColorSearchDto,IRequest<List<ColorDto>>
{

}