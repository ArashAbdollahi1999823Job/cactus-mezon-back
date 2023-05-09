using Domain.Entities.ChatEntity;
using Domain.Entities.MessageEntity;
using Microsoft.AspNetCore.Identity;
namespace Domain.Entities.IdentityEntity;

public class User:IdentityUser
{
    #region Properties
    public string Password { get; set; }
    #endregion

    #region Relation
    public Address Address { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }

    public ICollection<Message> MessagesSent { get; set; }
    public ICollection<Message> MessagesReceived { get; set; }

    public ICollection<Group> GroupAsker { get; set; }
    public ICollection<Group> GroupResponder { get; set; }
    #endregion
}