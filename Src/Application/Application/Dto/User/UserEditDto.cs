namespace Application.Dto.User;

public class UserEditDto
{
    public string Username { get; set; }
    public string PhoneNumber { get; set; }
    public string Id { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public string Password { get; set; }
    public List<string> Roles { set; get; }

    public UserEditDto(string username, string phoneNumber, string id, bool phoneNumberConfirmed, string password, List<string> roles)
    {
        Username = username;
        PhoneNumber = phoneNumber;
        Id = id;
        PhoneNumberConfirmed = phoneNumberConfirmed;
        Password = password;
        Roles = roles;
    }

    public UserEditDto()
    {
        
    }
}