﻿using Domain.Entities.IdentityEntity;
using Domain.Entities.InventoryEntity;
using Domain.Entities.PictureEntity;
namespace Domain.Entities.StoreEntity;
public class Store : BaseEntity.BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string MobileNumber { get; set; }
    public string Description { get; set; }

    public Store(string name, string address, string phoneNumber, string mobileNumber, string description, string userId)
    {
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        MobileNumber = mobileNumber;
        Description = description;
        UserId = userId;
    }
    public void Edit(string name, string address, string phoneNumber, string mobileNumber, string description, string userId)
    {
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        MobileNumber = mobileNumber;
        Description = description;
        UserId = userId;
    }

    //has few inventories
    public List<Inventory> Inventories { get; set; }
    // has few picture
    public List<StorePicture> StorePictures { get; set; }

    // has one user
    public User User { get; set; }
    public string UserId { get; set; }
}