namespace Application.Dto.Favorite;

public class FavoriteAddDto
{
    public string UserId { get; set; }
    public Guid ProductId { get; set; }

    public FavoriteAddDto(string userId, Guid productId)
    {
        UserId = userId;
        ProductId = productId;
    }

    public FavoriteAddDto()
    {
        
    }
}