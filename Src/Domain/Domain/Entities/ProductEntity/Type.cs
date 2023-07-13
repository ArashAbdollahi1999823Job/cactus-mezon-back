using Domain.Entities.PictureEntity;
namespace Domain.Entities.ProductEntity;
public class Type
{
    public Guid Id { get; set; }

    public bool IsActive { get; set; } = true;
    public bool IsDelete { get; set; } = false;
    public DateTime? LastModified { get; set; }
    public DateTime CreationDate { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public string Summary { get; set; }
    public string Slug { get; set; }
    public int  Sort { get; set; }
    public Type(string name, string description, string metaDescription, string summary, Guid? parentTypeId, string slug, int sort)
    {
        Name = name;
        Description = description;
        MetaDescription = metaDescription;
        Summary = summary;
        ParentTypeId = parentTypeId;
        Slug = slug;
        Sort = sort;
    }
    //has few product
    public List<Product> Products { get; set; }
    //has few items
    public List<TypeItem> TypeItems { get; set; }
    //has few pictures
    public List<TypePicture> TypePictures { get; set; }
    // has one type
    public Type ParentType { get; set; }
    public Guid? ParentTypeId { get; set; }

    public List<Type> ChildTypes { get; set; }
}
