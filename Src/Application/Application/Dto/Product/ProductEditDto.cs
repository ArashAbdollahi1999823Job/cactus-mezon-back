namespace Application.Dto.Product;

public class ProductEditDto
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public decimal Price { get; set; }
    public string Summary { get; set; }
    public Guid Id { get; set; }
    public bool IsActive { get; set; }


    public Guid BrandId { get; set; } 
    public Guid TypeId { get; set; }
    public Guid InventoryId { get; set; }
    public Guid OffId { get; set; }

    public ProductEditDto(string name, string slug, string description, string metaDescription, decimal price, string summary, Guid id, bool isActive, Guid brandId, Guid typeId, Guid inventoryId, Guid offId)
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