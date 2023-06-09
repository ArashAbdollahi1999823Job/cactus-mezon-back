namespace Application.Dto.Identity;

public class ForgetDto
{
    public string PhoneNumber { get; set; }

    public ForgetDto(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }

    public ForgetDto()
    {
        
    }
}