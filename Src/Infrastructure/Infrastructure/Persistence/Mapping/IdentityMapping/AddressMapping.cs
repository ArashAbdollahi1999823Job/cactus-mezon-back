#region UsingAndNamespace
using Domain.Entities.IdentityEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Persistence.Mapping.IdentityMapping;
#endregion
public class AddressMapping:IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasOne(x => x.User).WithOne(x => x.Address).HasForeignKey<Address>(x => x.UserId);
    }
}