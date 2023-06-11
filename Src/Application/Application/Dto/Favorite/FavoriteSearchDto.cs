namespace Application.Dto.Favorite;

public class FavoriteSearchDto
{
    public string UserId { get; set; }

    public FavoriteSearchDto(string userId)
    {
        UserId = userId;
    }

    public FavoriteSearchDto()
    {
        
    }
}