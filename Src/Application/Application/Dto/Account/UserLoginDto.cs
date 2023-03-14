namespace Application.Dto.Account;

public class UserLoginDto
{
    public string PhoneNumber { get; set; }
    public string Password { get; set; }

    public UserLoginDto(string phoneNumber, string password)
    {
        PhoneNumber = phoneNumber;
        Password = password;
    }

    public UserLoginDto()
    {
        
    }
}