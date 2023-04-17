namespace Application.Dto.TypeItem;

public class TypeItemAddDto
{
    public string Name { get; set; }

    public long TypeId { get; set; }

    public TypeItemAddDto(string name, long typeId)
    {
        Name = name;
        TypeId = typeId;
    }

    public TypeItemAddDto()
    {
        
    }
}