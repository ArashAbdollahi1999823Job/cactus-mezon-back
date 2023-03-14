namespace Application.Dto.StoreUser;
public class StoreUserEditDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string MobileNumber { get; set; }
    public string Description { get; set; }

    public StoreUserEditDto(long id, string name, string address, string phoneNumber, string mobileNumber, string description)
    {
        Id = id;
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        MobileNumber = mobileNumber;
        Description = description;
    }

    public StoreUserEditDto()
    {
        
    }
}