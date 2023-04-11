using Domain.Entities.PictureEntity;
namespace Domain.Entities.ProductEntity;
public class Type:BaseEntity.BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public string Summary { get; set; }
    public string Slug { get; set; }
    public Type(string name, string description, string metaDescription, string summary, long? parentTypeId, string slug)
    {
        Name = name;
        Description = description;
        MetaDescription = metaDescription;
        Summary = summary;
        ParentTypeId = parentTypeId;
        Slug = slug;
    }
    //has few product
    public List<Product> Products { get; set; }
    //has few items
    public List<Item> Items { get; set; }
    //has few pictures
    public List<TypePicture> TypePictures { get; set; }
    // has one type
    public Type ParentType { get; set; }
    public long? ParentTypeId { get; set; }

    public List<Type> ChildTypes { get; set; }
}
