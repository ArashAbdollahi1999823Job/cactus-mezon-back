using Domain.Entities.StoreEntity;

namespace Domain.Entities.PictureEntity;

public class StorePicture:BaseEntity.BaseEntity
{
    #region Properties
    public string PictureTitle { get; set; }
    public string PictureAlt { get; set; }
    public string PictureUrl { get; set; }
    public int Sort { get; set; }
    #endregion

    public StorePicture(string pictureTitle, string pictureAlt, string pictureUrl, int sort, Guid storeId)
    {
        PictureTitle = pictureTitle;
        PictureAlt = pictureAlt;
        PictureUrl = pictureUrl;
        Sort = sort;
        StoreId = storeId;
    }

    #region Relation
    public Store Store { get; set; }
    public Guid StoreId { get; set; }
    #endregion
}