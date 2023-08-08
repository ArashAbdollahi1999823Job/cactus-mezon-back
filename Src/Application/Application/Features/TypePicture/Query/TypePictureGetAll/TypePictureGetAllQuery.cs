using Application.Dto.TypePicture;
using Application.IContracts.IBehaviourPipe;
using MediatR;

namespace Application.Features.TypePicture.Query.TypePictureGetAll;
public class TypePictureGetAllQuery:TypePictureSearchDto,IRequest<List<TypePictureDto>>,IBehavioursCacheQuery
{
    public int MinutesCache { get; set; } = 0;
}