using Application.Dto.Favorite;
using Application.Dto.Product;
using Application.IContracts.IRepository;
using MediatR;

namespace Application.Features.Favorite.Query.FavoriteGetAll;

public class FavoriteGetAllQueryHandler:IRequestHandler<FavoriteGetAllQuery,List<ProductDto>>
{
    #region CtorAndInjection
    private readonly IFavoriteRepository _favoriteRepository;
    public FavoriteGetAllQueryHandler(IFavoriteRepository favoriteRepository)
    {
        _favoriteRepository = favoriteRepository;
    }
    #endregion
    
    public async Task<List<ProductDto>> Handle(FavoriteGetAllQuery req, CancellationToken cancellationToken)
    {
        var favoriteSearchDto = new FavoriteSearchDto(req.UserId);
        return await _favoriteRepository.FavoriteGetAllAsync(favoriteSearchDto,cancellationToken);
    }
}