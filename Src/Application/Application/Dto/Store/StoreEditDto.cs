namespace Application.Dto.Store;

public class StoreEditDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string MobileNumber { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }
    
    public string UserId { get; set; }

    public StoreEditDto(long id, string name, string address, string phoneNumber, string mobileNumber, string description, string userId,bool isActive)
    {
        Id = id;
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        MobileNumber = mobileNumber;
        Description = description;
        UserId = userId;
        IsActive = isActive;
    }

    public StoreEditDto()
    {
        
    }
}