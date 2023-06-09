namespace Application.IContracts.IRepository;

public interface IFavoriteRepository
{
    public Task<bool> FavoriteAddAsync(FavoriteAddDto favorireAddDto)
}