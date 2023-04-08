using Microsoft.AspNetCore.Http;
namespace Application.Dto.StoreUserPicture;
public class StoreUserPictureAddDto
{
    public string PictureTitle { get; set; }
    public string PictureAlt { get; set; }
    public IFormFile PictureUrl { get; set; }
    public string PictureUrlString { get; set; }
    public int Sort { get; set; }
    public Guid StoreId { get; set; }

    public StoreUserPictureAddDto(string pictureTitle, string pictureAlt, string pictureUrlString, int sort,Guid storeId)
    {
        PictureTitle = pictureTitle;
        PictureAlt = pictureAlt;
        PictureUrlString = pictureUrlString;
        StoreId = storeId;
        Sort = sort;
    }
    public StoreUserPictureAddDto()
    {
    }
}