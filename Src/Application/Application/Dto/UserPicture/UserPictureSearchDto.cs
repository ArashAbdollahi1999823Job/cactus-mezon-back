namespace Application.Dto.UserPicture;

public class UserPictureSearchDto
{
    public Guid Id { get; set; } 
    public string UserId { get; set; } 

    public UserPictureSearchDto(Guid id, string userId)
    {
        Id = id;
        UserId = userId;
    }

    public UserPictureSearchDto()
    {
        
    }
}