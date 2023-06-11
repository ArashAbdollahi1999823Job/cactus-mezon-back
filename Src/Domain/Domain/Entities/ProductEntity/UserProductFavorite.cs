using Domain.Entities.IdentityEntity;

namespace Domain.Entities.ProductEntity;

public class UserProductFavorite
{
    public User User { get; set; }
    public string UserId { get; set; }

    public Product Product { get; set; }
    public Guid ProductId { get; set; }

    public UserProductFavorite( string userId, Guid productId)
    {
        UserId = userId;
        ProductId = productId;
    }
}