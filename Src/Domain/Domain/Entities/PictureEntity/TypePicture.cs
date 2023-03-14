
using Type = Domain.Entities.ProductEntity.Type;

namespace Domain.Entities.PictureEntity;
public class TypePicture:BaseEntity.BaseEntity
{
    #region Properties
    public string PictureTitle { get; set; }
    public string PictureAlt { get; set; }
    public string PictureUrl { get; set; }
    public int Sort { get; set; }
    #endregion

    #region Ctor
    public TypePicture(string pictureTitle, string pictureAlt, string pictureUrl,int sort, long typeId)
    {
        PictureTitle = pictureTitle;
        PictureAlt = pictureAlt;
        PictureUrl = pictureUrl;
        TypeId = typeId;
        Sort = sort;
        CreationDate=DateTime.Now;
    }
    #endregion

    #region Relation
    //has one type
    public Type Type { get; set; }
    public long TypeId { get; set; }
    
    #endregion
}