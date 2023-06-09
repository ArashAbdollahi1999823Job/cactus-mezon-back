namespace Application.Dto.Identity;

public class CodeDto
{
    public string Code { get; set; }
    public string PhoneNumber { get; set; }

    public CodeDto(string code, string phoneNumber)
    {
        Code = code;
        PhoneNumber = phoneNumber;
    }

    public CodeDto()
    {
    }
}