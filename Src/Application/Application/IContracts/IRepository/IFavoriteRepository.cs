using Application.Dto.Favorite;
using Application.Dto.Product;

namespace Application.IContracts.IRepository;

public interface IFavoriteRepository
{
    public Task<bool> FavoriteAddAsync(FavoriteAddDto favoriteAddDto, CancellationToken cancellationToken);
    public Task<bool> FavoriteDeleteAsync(FavoriteDeleteDto favoriteDeleteDto, CancellationToken cancellationToken);
    public Task<bool> FavoriteExistAsync(FavoriteAddDto favoriteAddDto, CancellationToken cancellationToken);
    public Task<List<ProductDto>> FavoriteGetAllAsync(FavoriteSearchDto favoriteSearchDto, CancellationToken cancellationToken);
}