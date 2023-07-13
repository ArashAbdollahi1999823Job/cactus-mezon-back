namespace Application.Dto.StoreUser;
public class StoreUserEditDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string MobileNumber { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }

    public StoreUserEditDto(Guid id, string name, string address, string phoneNumber, string mobileNumber, string description, string slug)
    {
        Id = id;
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        MobileNumber = mobileNumber;
        Description = description;
        Slug = slug;
    }

    public StoreUserEditDto()
    {
    }
}