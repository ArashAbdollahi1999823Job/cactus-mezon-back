using Domain.Entities.ChatEntity;
using Domain.Entities.PictureEntity;
using Microsoft.AspNetCore.Identity;
namespace Domain.Entities.IdentityEntity;

public class User:IdentityUser
{
    #region Properties
    public string Password { get; set; }
    public string Description { get; set; }
    #endregion

    #region Relation
    public Address Address { get; set; }
    public UserPicture UserPicture { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<Message> MessagesSent { get; set; }
    public ICollection<Message> MessagesReceived { get; set; }
    public ICollection<Group> GroupAsker { get; set; }
    public ICollection<Group> GroupResponder { get; set; }
    #endregion
}