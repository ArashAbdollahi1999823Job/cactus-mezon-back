namespace Application.Dto.ProductPicture;

public class ProductPictureEditDto
{
    public Guid Id { get; set; }
    public string PictureAlt { get; set; }
    public string PictureTitle  { get; set; }
    public int  Sort { get; set; }
    public bool IsActive { get; set; }

    public ProductPictureEditDto(Guid id, string pictureAlt, string pictureTitle, int sort, bool isActive)
    {
        Id = id;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        Sort = sort;
        IsActive = isActive;
    }

    public ProductPictureEditDto()
    {
        
    }
}