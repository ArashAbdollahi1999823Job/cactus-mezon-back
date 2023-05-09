using Domain.Entities.IdentityEntity;
using Domain.Entities.ProductEntity;
namespace Domain.Entities.PictureEntity;
public class UserPicture
{
    public Guid Id { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime? LastModified { get; set; }
    public DateTime CreationDate { get; set; }
    public string PictureTitle { get; set; }
    public string PictureAlt { get; set; }
    public string PictureUrl { get; set; }
    public int Sort { get; set; }

    public UserPicture(string pictureTitle, string pictureAlt, string pictureUrl, int sort, string userId)
    {
        PictureTitle = pictureTitle;
        PictureAlt = pictureAlt;
        PictureUrl = pictureUrl;
        Sort = sort;
        UserId = userId;
    }

    public User User { get; set; }
    public string UserId { get; set; }
}

