using Domain.Entities.StoreEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Persistence.Mapping.ProductMapping;

public class OffMapping:IEntityTypeConfiguration<Off>
{
    public void Configure(EntityTypeBuilder<Off> builder)
    {
        #region Properties
        #endregion
    }
}
