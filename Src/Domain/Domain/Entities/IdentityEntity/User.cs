using Domain.Entities.ChatEntity;
using Domain.Entities.PictureEntity;
using Domain.Entities.ProductEntity;
using Domain.Entities.StoreEntity;
using Microsoft.AspNetCore.Identity;
namespace Domain.Entities.IdentityEntity;

public class User:IdentityUser
{
    #region Properties
    public string Password { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public string Code { set; get; }
    #endregion

    #region Relation
    public Store? Store { get; set; }
    public UserPicture UserPicture { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<Message> MessagesSent { get; set; }
    public ICollection<Message> MessagesReceived { get; set; }
    public ICollection<Group>? GroupAsker { get; set; }
    public ICollection<Group>? GroupResponder { get; set; }
    public ICollection<UserProductFavorite> UserProductFavorites { get; set; }
    #endregion
}