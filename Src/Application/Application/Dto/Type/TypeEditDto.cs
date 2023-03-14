namespace Application.Dto.Type;

public class TypeEditDto
{
    public long Id { get; set; }
    public long ParentTypeId { get; set; } = 0;
    public string Name { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public string Summary { get; set; }
    public bool IsActive { set; get; } 
    public bool IsDelete { get; set; } = false;

    public TypeEditDto(long id, long parentTypeId, string name, string description, string metaDescription, string summary, bool isActive, bool isDelete)
    {
        Id = id;
        ParentTypeId = parentTypeId;
        Name = name;
        Description = description;
        MetaDescription = metaDescription;
        Summary = summary;
        IsActive = isActive;
        IsDelete = isDelete;
    }

    public TypeEditDto()
    {
        
    }
}