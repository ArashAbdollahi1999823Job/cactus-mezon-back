using Domain.Entities.IdentityEntity;
namespace Domain.Entities.PictureEntity;
public class UserPicture
{
    public Guid Id { get; set; }
    public string PictureUrl { get; set; }

    public UserPicture( string pictureUrl, string userId)
    {
        PictureUrl = pictureUrl;
        UserId = userId;
    }

    public User User { get; set; }
    public string UserId { get; set; }
}

