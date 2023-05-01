namespace Application.Dto.TypeItem;

public class TypeItemSearchDto
{
    public Guid Id { get; set; }

    public Guid TypeId { get; set; }

    public TypeItemSearchDto(Guid id, Guid typeId)
    {
        Id = id;
        TypeId = typeId;
    }

    public TypeItemSearchDto()
    {
        
    }
}