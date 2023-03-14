#region UsingAndNamespace
using Domain.Entities.ProductEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Persistence.Mapping.ProductMapping;
#endregion
public class ProductMapping:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        #region Properties
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
        builder.Property(x => x.MetaDescription).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Summary).HasMaxLength(100).IsRequired();
        #endregion

        #region Relations
      //  builder.HasOne(x => x.ProductType).WithMany().HasForeignKey(x => x.ProductTypeId);
       // builder.HasOne(x => x.ProductBrand).WithMany().HasForeignKey(x => x.ProductBrandId);
        /*builder.HasOne(x => x.ShopSeller).WithMany().HasForeignKey(x => x.ShopSellerId);*/

       // builder.HasMany(x => x.ProductPictures).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
        #endregion
    }
}
