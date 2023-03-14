namespace Application.Dto.Store;

public class StoreAddDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string MobileNumber { get; set; }
    public string Description { get; set; }
    
    public string UserId { get; set; }


    public StoreAddDto(string name, string address, string phoneNumber, string mobileNumber, string description, string userId)
    {
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        MobileNumber = mobileNumber;
        Description = description;
        UserId = userId;
    }

    public StoreAddDto()
    {
        
    }
}