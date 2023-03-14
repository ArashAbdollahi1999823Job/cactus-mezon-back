#region UsingAndNamespace

using Domain.Entities.ProductEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Mapping.ProductMapping;
#endregion
public class ProductBrandMapping:IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
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
