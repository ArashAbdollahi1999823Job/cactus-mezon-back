namespace Application.Dto.Product;

public class ProductEditDto
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public decimal Price { get; set; }
    public string Summary { get; set; }
    public long Id { get; set; }
    public bool IsActive { get; set; }


    public long BrandId { get; set; } = 0;
    public long TypeId { get; set; }
    public long InventoryId { get; set; }
    public long OffId { get; set; }

    public ProductEditDto(string name, string slug, string description, string metaDescription, decimal price, string summary, long id, bool isActive, long brandId, long typeId, long inventoryId, long offId)
    {
        Name = name;
        Slug = slug;
        Description = description;
        MetaDescription = metaDescription;
        Price = price;
        Summary = summary;
        Id = id;
        IsActive = isActive;
        BrandId = brandId;
        TypeId = typeId;
        InventoryId = inventoryId;
        OffId = offId;
    }

    public ProductEditDto()
    {
      
    }
}