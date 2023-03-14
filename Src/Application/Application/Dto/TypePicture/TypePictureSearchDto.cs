namespace Application.Dto.TypePicture;

public class TypePictureSearchDto
{
    public long Id { get; set; } = 0;
    public long TypeId { get; set; } = 0;

    public TypePictureSearchDto(long id, long typeId)
    {
        Id = id;
        TypeId = typeId;
    }

    public TypePictureSearchDto()
    {
        
    }
}