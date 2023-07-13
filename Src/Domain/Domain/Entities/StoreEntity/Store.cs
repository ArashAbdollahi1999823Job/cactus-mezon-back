using System.ComponentModel.DataAnnotations;
using Domain.Entities.IdentityEntity;
using Domain.Entities.InventoryEntity;
using Domain.Entities.PictureEntity;
namespace Domain.Entities.StoreEntity;
public class Store 
{
    
    public bool IsActive { get; set; } = true;
    public DateTime? LastModified { get; set; }
    public DateTime CreationDate { get; set; }
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string MobileNumber { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }

    public Store(string name, string address, string phoneNumber, string mobileNumber, string description, string userId, string slug)
    {
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        MobileNumber = mobileNumber;
        Description = description;
        UserId = userId;
        Slug = slug;
    }

    //has few inventories
    public List<Inventory> Inventories { get; set; }
    // has few picture
    public List<StorePicture> StorePictures { get; set; }

    // has one user
    public User User { get; set; }
    public string? UserId { get; set; }
}