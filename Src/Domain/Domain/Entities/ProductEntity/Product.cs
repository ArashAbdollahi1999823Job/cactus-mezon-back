using Domain.Entities.CommentEntity;
using Domain.Entities.InventoryEntity;
using Domain.Entities.PictureEntity;
using Domain.Entities.StoreEntity;
namespace Domain.Entities.ProductEntity;
public class Product :BaseEntity.BaseEntity
{
    #region Properties
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public decimal Price { get; set; }
    public string Summary { get; set; }

 

    public long Score { get; set; }
    public int Count { get; set; }
    #endregion


    public Product(string name, string slug, string description, string metaDescription, decimal price, string summary, long inventoryId,  long typeId, long? brandId)
    {
        Name = name;
        Slug = slug;
        Description = description;
        MetaDescription = metaDescription;
        Price = price;
        Summary = summary;
        InventoryId = inventoryId;
        TypeId = typeId;
        BrandId = brandId;
    }

    #region Rilations
    // has one off
    public Off Off { get; set; }
    public long? OffId { get; set; }
    // has one inventory
    public long InventoryId { get; set; }
    public Inventory Inventory { get; set; }
    //has one type
    public long TypeId { get; set; }
    public Type Type { get; set; }
    //has one brand
    public long? BrandId { get; set; }
    public Brand Brand { get; set; }
    //has few pictures
    public List<ProductPicture> ProductPictures { get; set; }
    //has few comment
    public List<Comment> Comments { get; set; }
    //has few items
    public List<Item> Items { get; set; }
    #endregion
}