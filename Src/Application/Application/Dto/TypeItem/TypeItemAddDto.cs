namespace Application.Dto.TypeItem;

public class TypeItemAddDto
{
    public string Name { get; set; }

    public Guid TypeId { get; set; }

    public TypeItemAddDto(string name, Guid typeId)
    {
        Name = name;
        TypeId = typeId;
    }

    public TypeItemAddDto()
    {
        
    }
}