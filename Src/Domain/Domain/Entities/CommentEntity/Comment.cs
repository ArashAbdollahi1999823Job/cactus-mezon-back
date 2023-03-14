#region UsingAndNamespace
using Domain.Entities.IdentityEntity;
using Domain.Entities.ProductEntity;
namespace Domain.Entities.CommentEntity;
#endregion
public class Comment:BaseEntity.BaseEntity
{
    public string Description { get; set; }
    
    
    //has one user
    public User User { get; set; }
    public string UserId { get; set; }
    // has one product
    public Product Product { get; set; }
    public long ProductId { get; set; }
    // has one user answer
    public User UserAnswer { get; set; }
    public string UserAnswerId { get; set; }
}