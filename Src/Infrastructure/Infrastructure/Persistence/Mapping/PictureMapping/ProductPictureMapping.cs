#region UsingAndNamespace

using Domain.Entities.PictureEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Mapping.PictureMapping;
#endregion
public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
{
    public void Configure(EntityTypeBuilder<ProductPicture> builder)
    {
        #region Properties
        builder.Property(x => x.PictureAlt).HasMaxLength(100).IsRequired();
        builder.Property(x => x.PictureTitle).HasMaxLength(100).IsRequired();
        builder.Property(x => x.PictureUrl).HasMaxLength(500).IsRequired();
        #endregion

        #region Relations
        builder.HasOne(x => x.Product).WithMany(x => x.ProductPictures).HasForeignKey(x => x.ProductId);
        #endregion
    }
}

