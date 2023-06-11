using Application.Dto.Favorite;
using Application.IContracts.IRepository;
using MediatR;
namespace Application.Features.Favorite.Command.FavoriteAdd;
public class FavoriteAddCommandHandler : IRequestHandler<FavoriteAddCommand, bool>
{
    #region CtorAndInjection
    private readonly IFavoriteRepository _favoriteRepository;
    public FavoriteAddCommandHandler(IFavoriteRepository favoriteRepository)
    {
        _favoriteRepository = favoriteRepository;
    }
    #endregion
    
    public async Task<bool> Handle(FavoriteAddCommand req, CancellationToken cancellationToken)
    {
        var favoriteAddDto = new FavoriteAddDto(req.UserId,req.ProductId);
        var check = await _favoriteRepository.FavoriteExistAsync(favoriteAddDto,cancellationToken);
        if (check) return true;
        return await _favoriteRepository.FavoriteAddAsync(favoriteAddDto, cancellationToken);
    }
}