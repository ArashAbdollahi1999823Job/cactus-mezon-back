﻿namespace Application.Dto.Type;
public class TypeAddDto
{
    public Guid ParentTypeId { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public string Summary { get; set; }
    public string Slug { get; set; }
    public int  Sort { set; get; }


    public TypeAddDto(Guid parentTypeId, string name, string description, string metaDescription, string summary, string slug, int sort)
    {
        ParentTypeId = parentTypeId;
        Name = name;
        Description = description;
        MetaDescription = metaDescription;
        Summary = summary;
        Slug = slug;
        Sort = sort;
    }
    public TypeAddDto()
    {
    }
}