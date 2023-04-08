namespace Application.Dto.StoreUserPicture;

public class StoreUserPictureSearchDto
{
    public long Id { get; set; } = 0;
    public Guid StoreId { get; set; }

    public StoreUserPictureSearchDto(long id, Guid storeId)
    {
        Id = id;
        StoreId = storeId;
    }
    public StoreUserPictureSearchDto()
    {
    }
}