namespace Domain.Entities.IdentityEntity;

public class UserVerify
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Code { get; set; }
    public DateTime CreationDate { get; set; }

    public UserVerify( string name, string password, string phoneNumber, string code)
    {
        Name = name;
        Password = password;
        PhoneNumber = phoneNumber;
        Code = code;
        CreationDate=DateTime.Now;
    }
}