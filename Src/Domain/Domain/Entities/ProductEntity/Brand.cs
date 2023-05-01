namespace Domain.Entities.ProductEntity;
public class Brand
{
    public Guid Id { get; set; }
    public DateTime? LastModified { get; set; }
    public DateTime CreationDate { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public string Summary { get; set; }

    public Brand(string name, string description, string metaDescription, string summary)
    {
        Name = name;
        Description = description;
        MetaDescription = metaDescription;
        Summary = summary;
    }
    public List<Product> Products { get; set; }
}

