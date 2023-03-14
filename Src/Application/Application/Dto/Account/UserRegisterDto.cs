namespace Application.Dto.Account;

public class UserRegister
{
    public string PhoneNumber { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public UserRegister(string phoneNumber, string username, string password)
    {
        PhoneNumber = phoneNumber;
        Username = username;
        Password = password;
    }

    public UserRegister()
    {
        
    }
}