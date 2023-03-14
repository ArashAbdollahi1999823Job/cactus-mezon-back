namespace Application.Dto.StoreUserPicture;

public class StoreUserPictureSearchDto
{
    public long Id { get; set; } = 0;
    public long StoreId { get; set; } = 0;

    public StoreUserPictureSearchDto(long id, long storeId)
    {
        Id = id;
        StoreId = storeId;
    }
    public StoreUserPictureSearchDto()
    {
    }
}