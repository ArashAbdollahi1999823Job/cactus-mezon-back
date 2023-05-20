namespace Application.Dto.User;

public class UserAddDto
{
    public string Username { get; set; }
    public string PhoneNumber { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public string Password { get; set; }
    public List<string>? Roles { set; get; }
    public string Description { get; set; }

    
    public UserAddDto(string username, string phoneNumber, bool phoneNumberConfirmed, string password, List<string> roles, string description)
    {
        Username = username;
        PhoneNumber = phoneNumber;
        PhoneNumberConfirmed = phoneNumberConfirmed;
        Password = password;
        Roles = roles;
        Description = description;
    }

    public UserAddDto()
    {
    }
}