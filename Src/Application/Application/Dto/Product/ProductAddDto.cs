namespace Application.Dto.Product;

public class ProductAddDto
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public decimal Price { get; set; }
    public string Summary { get; set; }
    
    
    public Guid BrandId { get; set; }
    public Guid TypeId { get; set; }
    public Guid InventoryId { get; set; }

    public ProductAddDto(string name, string slug, string description, string metaDescription, decimal price, string summary, Guid brandId, Guid typeId, Guid inventoryId)
    {
        Name = name;
        Slug = slug;
        Description = description;
        MetaDescription = metaDescription;
        Price = price;
        Summary = summary;
        BrandId = brandId;
        TypeId = typeId;
        InventoryId = inventoryId;
    }

    public ProductAddDto()
    {
        
    }
}