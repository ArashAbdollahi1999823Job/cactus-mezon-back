namespace Application.Dto.Type;
public class TypeAddDto
{
    public long ParentTypeId { get; set; } = 0;
    public string Name { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public string Summary { get; set; }

    public TypeAddDto(long parentTypeId, string name, string description, string metaDescription, string summary)
    {
        ParentTypeId = parentTypeId;
        Name = name;
        Description = description;
        MetaDescription = metaDescription;
        Summary = summary;
    }
    public TypeAddDto()
    {
        
    }
}