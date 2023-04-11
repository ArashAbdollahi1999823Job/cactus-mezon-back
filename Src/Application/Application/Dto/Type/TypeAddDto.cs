namespace Application.Dto.Type;
public class TypeAddDto
{
    public long ParentTypeId { get; set; } = 0;
    public string Name { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public string Summary { get; set; }
    public string Slug { get; set; }


    public TypeAddDto(long parentTypeId, string name, string description, string metaDescription, string summary, string slug)
    {
        ParentTypeId = parentTypeId;
        Name = name;
        Description = description;
        MetaDescription = metaDescription;
        Summary = summary;
        Slug = slug;
    }
    public TypeAddDto()
    {
    }
}