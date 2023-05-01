namespace Application.Dto.StoreUserPicture;

public class StoreUserPictureSearchDto
{
    public Guid Id { get; set; }
    public Guid StoreId { get; set; }

    public StoreUserPictureSearchDto(Guid id, Guid storeId)
    {
        Id = id;
        StoreId = storeId;
    }
    public StoreUserPictureSearchDto()
    {
    }
}