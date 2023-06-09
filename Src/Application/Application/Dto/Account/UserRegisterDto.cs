namespace Application.Dto.Account;

public class UserRegister
{
    public string PhoneNumber { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }

    public UserRegister(string phoneNumber, string name, string password)
    {
        PhoneNumber = phoneNumber;
        Name = name;
        Password = password;
    }

    public UserRegister()
    {
        
    }
}