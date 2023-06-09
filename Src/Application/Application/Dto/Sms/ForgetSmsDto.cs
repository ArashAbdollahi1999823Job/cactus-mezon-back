namespace Application.Dto.Sms;

public class ForgetSmsDto
{
    public string PhoneNumber { get; set; }
    public string Password { get; set; }

    public ForgetSmsDto(string phoneNumber, string password)
    {
        PhoneNumber = phoneNumber;
        Password = password;
    }
}