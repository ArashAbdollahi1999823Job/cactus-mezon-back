#region UsingAndNamespace

using Domain.Entities.BaseEntity;
using Domain.Entities.BaseEntity.Command;
using Domain.Entities.ProductEntity;

namespace Domain.Entities.PictureEntity;
#endregion
public class ProductPicture : BaseEntity.BaseEntity
{
    #region Properties
    public string PictureTitle { get; set; }
    public string PictureAlt { get; set; }
    public string PictureUrl { get; set; }
    public int Sort { get; set; }

    #endregion

    public ProductPicture(string pictureTitle, string pictureAlt, string pictureUrl, int sort, long productId)
    {
        PictureTitle = pictureTitle;
        PictureAlt = pictureAlt;
        PictureUrl = pictureUrl;
        Sort = sort;
        ProductId = productId;
    }

    #region Relation
    public Product Product { get; set; }
    public long ProductId { get; set; }
    #endregion
}

