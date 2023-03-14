namespace Application.Dto.StoreUserPicture;

public class StoreUserPictureEditDto
{
    public long Id { get; set; }
    public string PictureAlt { get; set; }
    public string PictureTitle  { get; set; }
    public int  Sort { get; set; }
    public bool IsActive { get; set; }

    public StoreUserPictureEditDto(long id, string pictureAlt, string pictureTitle, int sort, bool isActive)
    {
        Id = id;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        Sort = sort;
        IsActive = isActive;
    }

    public StoreUserPictureEditDto()
    {
        
    }
}