using Domain.Entities.StoreEntity;

namespace Domain.Entities.PictureEntity;

public class StorePicture
{
    public Guid Id { get; set; }

    public bool IsActive { get; set; } = true;
    public DateTime? LastModified { get; set; }
    public DateTime CreationDate { get; set; }
    public string PictureTitle { get; set; }
    public string PictureAlt { get; set; }
    public string PictureUrl { get; set; }
    public int Sort { get; set; }

    public StorePicture(string pictureTitle, string pictureAlt, string pictureUrl, int sort, Guid storeId)
    {
        PictureTitle = pictureTitle;
        PictureAlt = pictureAlt;
        PictureUrl = pictureUrl;
        Sort = sort;
        StoreId = storeId;
    }

    public Store Store { get; set; }
    public Guid StoreId { get; set; }
}