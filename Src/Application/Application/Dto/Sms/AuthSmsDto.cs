namespace Application.Dto.Sms;

public class AuthSmsDto
{
    public string PhoneNumber { get; set; }
    public string Code { get; set; }

    public AuthSmsDto(string phoneNumber, string code)
    {
        PhoneNumber = phoneNumber;
        Code = code;
    }
}