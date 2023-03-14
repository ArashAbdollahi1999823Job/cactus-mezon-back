using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Type = Domain.Entities.ProductEntity.Type;
namespace Infrastructure.Persistence.Mapping.ProductMapping;
public class ProductTypeMapping : IEntityTypeConfiguration<Type>
{
    public void Configure(EntityTypeBuilder<Type> builder)
    {
        #region Properties
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Summary).HasMaxLength(100).IsRequired();
        builder.Property(x => x.MetaDescription).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
        #endregion
    }
}
