namespace Application.Dto.Favorite;

public class FavoriteDeleteDto
{
    public string UserId { get; set; }
    public Guid ProductId { get; set; }

    public FavoriteDeleteDto(string userId, Guid productId)
    {
        UserId = userId;
        ProductId = productId;
    }

    public FavoriteDeleteDto()
    {
        
    }
}