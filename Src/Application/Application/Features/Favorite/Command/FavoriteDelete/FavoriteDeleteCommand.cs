using Application.Dto.Favorite;
using AutoMapper.Configuration;
using MediatR;

namespace Application.Features.Favorite.Command.FavoriteDelete;

public class FavoriteDeleteCommand:FavoriteDeleteDto,IRequest<bool>
{
    public FavoriteDeleteCommand(string userId,Guid productId)
    {
        UserId = userId;
        ProductId = productId;
    }
}