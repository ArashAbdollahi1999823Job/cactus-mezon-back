using Domain.Entities.CommentEntity;
using Domain.Entities.IdentityEntity;
using Domain.Entities.InventoryEntity;
using Domain.Entities.PictureEntity;
using Domain.Entities.StoreEntity;
namespace Domain.Entities.ProductEntity;
public class Product
{
    public Guid Id { get; set; }

    public bool IsActive { get; set; } = true;
    public DateTime? LastModified { get; set; }
    public DateTime CreationDate { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public decimal Price { get; set; }
    public string Summary { get; set; }
    
    public long Score { get; set; }
    public int Count { get; set; }
    
    public Product(string name, string slug, string description, string metaDescription, decimal price, string summary, Guid inventoryId,  Guid typeId, Guid? brandId)
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
    public Off Off { get; set; }
    public Guid? OffId { get; set; }
    public Guid InventoryId { get; set; }
    public Inventory Inventory { get; set; }
    public Guid TypeId { get; set; }
    public Type Type { get; set; }
    public Guid? BrandId { get; set; }
    public Brand Brand { get; set; }
    public List<ProductPicture> ProductPictures { get; set; }
    public List<Comment> Comments { get; set; }
    public List<ProductItem> ProductItems { get; set; }
    public List<Color> Colors { get; set; }
    public ICollection<UserProductFavorite> UserProductFavorites { get; set; }
}