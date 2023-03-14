#region UsignAndNamespace

using Domain.Entities.BaseEntity;
using Domain.Entities.BaseEntity.Command;
using Domain.Entities.PictureEntity;

namespace Domain.Entities.ProductEntity;
#endregion
public class Type:BaseEntity.BaseEntity
{
    #region Properties
    public string Name { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public string Summary { get; set; }
    #endregion
    public Type(string name, string description, string metaDescription, string summary, long? parentTypeId)
    {
        Name = name;
        Description = description;
        MetaDescription = metaDescription;
        Summary = summary;
        ParentTypeId = parentTypeId;
    }

    #region Relations
    //has few product
    public List<Product> Products { get; set; }
    //has few items
    public List<Item> Items { get; set; }
    //has few pictures
    public List<TypePicture> TypePictures { get; set; }
    // has one type
    public Type ParentType { get; set; }
    public long? ParentTypeId { get; set; }
    #endregion
}
