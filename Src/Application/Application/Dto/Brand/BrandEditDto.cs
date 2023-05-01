namespace Application.Dto.Brand;

public class BrandEditDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public string Summary { get; set; }

    public BrandEditDto(Guid id, string name ,string description, string metaDescription, string summary)
    {
        Id = id;
        Name = name;
        Description = description;
        MetaDescription = metaDescription;
        Summary = summary;
    }

    public BrandEditDto()
    {
        
    }
}