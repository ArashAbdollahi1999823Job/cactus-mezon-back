using Microsoft.AspNetCore.Http;

namespace Application.Dto.UserPicture;
public class UserPictureAddDto
{
    public IFormFile PictureUrl { get; set; }
    public string PictureUrlString { get; set; }
    public string UserId { get; set; }

    public UserPictureAddDto( string pictureUrlString, string userId)
    {
        PictureUrlString = pictureUrlString;
        UserId = userId;
    }

    public UserPictureAddDto()
    {
        
    }
}