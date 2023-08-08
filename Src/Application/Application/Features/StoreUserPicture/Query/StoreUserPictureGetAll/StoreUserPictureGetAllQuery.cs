using Application.Dto.StoreUserPicture;
using Application.IContracts.IBehaviourPipe;
using MediatR;

namespace Application.Features.StoreUserPicture.Query.StoreUserPictureGetAll;
public class StoreUserPictureGetAllQuery:StoreUserPictureSearchDto,IRequest<List<StoreUserPictureDto>>,IBehavioursCacheQuery
{
    public int MinutesCache { get; set; } = 0;
}
