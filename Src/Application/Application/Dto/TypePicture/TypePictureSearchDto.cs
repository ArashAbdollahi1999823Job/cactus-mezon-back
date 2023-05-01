namespace Application.Dto.TypePicture;

public class TypePictureSearchDto
{
    public Guid Id { get; set; } 
    public Guid TypeId { get; set; } 

    public TypePictureSearchDto(Guid id, Guid typeId)
    {
        Id = id;
        TypeId = typeId;
    }

    public TypePictureSearchDto()
    {
        
    }
}