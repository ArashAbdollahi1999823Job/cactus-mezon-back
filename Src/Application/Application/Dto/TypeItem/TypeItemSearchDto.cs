namespace Application.Dto.TypeItem;

public class TypeItemSearchDto
{
    public long Id { get; set; }

    public long TypeId { get; set; }

    public TypeItemSearchDto(long id, long typeId)
    {
        Id = id;
        TypeId = typeId;
    }

    public TypeItemSearchDto()
    {
        
    }
}