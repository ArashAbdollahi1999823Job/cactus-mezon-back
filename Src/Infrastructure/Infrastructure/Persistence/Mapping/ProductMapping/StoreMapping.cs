using Domain.Entities.ProductEntity;
using Domain.Entities.StoreEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Persistence.Mapping.ProductMapping;
public class StoreMapping:IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder
            .HasOne(x => x.User)
            .WithOne(x => x.Store)
            .HasForeignKey<Store>(x => x.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .IsRequired(false);
    }
}
