using Microsoft.AspNetCore.Http;
namespace Application.Dto.TypePicture;
public class TypePictureAddDto
{
    public string PictureTitle { get; set; }
    public string PictureAlt { get; set; }
    public IFormFile PictureUrl { get; set; }
    public string PictureUrlString { get; set; }
    public int Sort { get; set; }
    public long TypeId { get; set; }

    public TypePictureAddDto(string pictureTitle, string pictureAlt, string pictureUrlString, int sort, long typeId)
    {
        PictureTitle = pictureTitle;
        PictureAlt = pictureAlt;
        PictureUrlString = pictureUrlString;
        Sort = sort;
        TypeId = typeId;
    }

    public TypePictureAddDto()
    {
        
    }
}