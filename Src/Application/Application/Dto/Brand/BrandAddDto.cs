namespace Application.Dto.Brand;

public class BrandAddDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public string Summary { get; set; }

    public BrandAddDto(string name, string description, string metaDescription, string summary)
    {
        Name = name;
        Description = description;
        MetaDescription = metaDescription;
        Summary = summary;
    }

    public BrandAddDto()
    {
        
    }
}