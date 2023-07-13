namespace Application.Dto.Store;

public class StoreEditDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string MobileNumber { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public string UserId { get; set; }
    public string Slug { get; set; }


    public StoreEditDto(Guid id, string name, string address, string phoneNumber, string mobileNumber, string description, string userId,bool isActive, string slug)
    {
        Id = id;
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        MobileNumber = mobileNumber;
        Description = description;
        UserId = userId;
        IsActive = isActive;
        Slug = slug;
    }

    public StoreEditDto()
    {
    }
}