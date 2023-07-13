namespace Application.Dto.StoreUserPicture;

public class StoreUserPictureSearchDto
{
    public Guid Id { get; set; }
    public Guid StoreId { get; set; }
    public int Sort { get; set; } = 0;
    public int StartRange { get; set; } = 0;
    public int EndRange { get; set; } = 0;

    public StoreUserPictureSearchDto(Guid id, Guid storeId, int sort, int startRange, int endRange)
    {
        Id = id;
        StoreId = storeId;
        Sort = sort;
        StartRange = startRange;
        EndRange = endRange;
    }
    public StoreUserPictureSearchDto()
    {
    }
}