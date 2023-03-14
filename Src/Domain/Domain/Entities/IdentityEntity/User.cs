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
    #endregion
}