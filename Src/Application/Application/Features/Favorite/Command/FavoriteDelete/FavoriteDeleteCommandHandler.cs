using Application.Dto.Favorite;
using Application.IContracts.IRepository;
using MediatR;

namespace Application.Features.Favorite.Command.FavoriteDelete;

public class FavoriteDeleteCommandHandler:IRequestHandler<FavoriteDeleteCommand,bool>
{
    #region CtorAndInjection
    private readonly IFavoriteRepository _favoriteRepository;
    public FavoriteDeleteCommandHandler(IFavoriteRepository favoriteRepository)
    {
        _favoriteRepository = favoriteRepository;
    }
    #endregion
    
    public Task<bool> Handle(FavoriteDeleteCommand req, CancellationToken cancellationToken)
    {
        var favoriteDeleteDto = new FavoriteDeleteDto(req.UserId,req.ProductId);
        return _favoriteRepository.FavoriteDeleteAsync(favoriteDeleteDto, cancellationToken);
    }
}