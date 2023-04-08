namespace Application.Dto.StoreUser;
public class StoreUserSearchDto
{
    public Guid Id { get; set; }
    public string UserId { get; set; }


    public StoreUserSearchDto(Guid id, string userId)
    {
        Id = id;
        UserId = userId;
    }

    public StoreUserSearchDto()
    {
        
    }
}