using Microsoft.AspNetCore.Identity;
namespace Domain.Entities.IdentityEntity;
public class Role:IdentityRole<string>
{
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}