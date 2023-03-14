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

    #endregion
    
    #region Relation
    public Product Product { get; set; }
    public long ProductId { get; set; }
    #endregion
}

