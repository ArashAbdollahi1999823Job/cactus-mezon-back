namespace Application.Dto.StoreUser;
public class StoreUserSearchDto
{
    public long Id { get; set; }
    public string UserId { get; set; }


    public StoreUserSearchDto(long id, string userId)
    {
        Id = id;
        UserId = userId;
    }

    public StoreUserSearchDto()
    {
        
    }
}