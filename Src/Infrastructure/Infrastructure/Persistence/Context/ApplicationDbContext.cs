using System.Reflection;
using Domain.Entities.ChatEntity;
using Domain.Entities.IdentityEntity;
using Domain.Entities.InventoryEntity;
using Domain.Entities.PictureEntity;
using Domain.Entities.ProductEntity;
using Domain.Entities.StoreEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Type = Domain.Entities.ProductEntity.Type;
namespace Infrastructure.Persistence.Context;

public class ApplicationDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>, UserRole,
    IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
{
    #region Ctor
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    #endregion
    
    #region IdentityUser

    public DbSet<User> Users => Set<User>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Role> Roles => Set<Role>();
    
    public DbSet<UserRole> UserRoles { get; set; }

    #endregion

    #region Product
    public DbSet<Color> Colors => Set<Color>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Type> Types => Set<Type>();
    public DbSet<ProductItem> ProductItems { get; set; }
    public DbSet<TypeItem> TypeItems { get; set; }

    #endregion #Product

    #region Pictures

    public DbSet<ProductPicture> ProductPictures => Set<ProductPicture>();
    public DbSet<StorePicture> StorePictures => Set<StorePicture>();
    public DbSet<TypePicture> TypePictures => Set<TypePicture>();
    public DbSet<UserPicture> UserPictures => Set<UserPicture>();

    #endregion

    #region Store
    public DbSet<Store> Stores { get; set; }
    public DbSet<Off> Offs { get; set; }
    #endregion

    #region Inventory
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<InventoryOperation> InventoryOperations { get; set; }
    #endregion

    #region Message
    public DbSet<Message> Messages { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Connection> Connections { get; set; }
    #endregion

    #region OnModelCreating
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<Type>().HasQueryFilter(x => x.IsDelete == false);
        modelBuilder.Entity<Address>().HasQueryFilter(x => x.IsDelete == false);
        modelBuilder.Entity<Off>().HasQueryFilter(x => x.EndDate >DateTime.Now);
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims"); 
        modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins"); 
        modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
        modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
    }
    #endregion
}