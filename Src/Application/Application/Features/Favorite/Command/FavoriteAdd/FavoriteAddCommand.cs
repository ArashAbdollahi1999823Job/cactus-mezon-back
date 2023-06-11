using Application.Dto.Favorite;
using MediatR;

namespace Application.Features.Favorite.Command.FavoriteAdd;

public class FavoriteAddCommand:FavoriteAddDto,IRequest<bool>
{
    
}