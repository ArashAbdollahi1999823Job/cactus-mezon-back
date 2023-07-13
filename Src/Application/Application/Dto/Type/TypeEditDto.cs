namespace Application.Dto.Type;
public class TypeEditDto
{
    public Guid Id { get; set; }
    public Guid ParentTypeId { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public string Summary { get; set; }
    public bool IsActive { set; get; } 
    public bool IsDelete { get; set; } = false;
    public int Sort { get; set; }

    public TypeEditDto(Guid id, Guid parentTypeId, string name, string description, string metaDescription, string summary, bool isActive, bool isDelete, string slug, int sort)
    {
        Id = id;
        ParentTypeId = parentTypeId;
        Name = name;
        Description = description;
        MetaDescription = metaDescription;
        Summary = summary;
        IsActive = isActive;
        IsDelete = isDelete;
        Slug = slug;
        Sort = sort;
    }

    public TypeEditDto()
    {
    }
}