using Domain.Entities.IdentityEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Persistence.Mapping.IdentityMapping;
public class UserMapping:IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.UserName).IsRequired();
        builder.Property(x => x.Email).IsRequired(false);
        builder.ToTable("Users");
        
        
        /*builder
            .HasMany(x => x.GroupAsker)
            .WithOne(x=>x.Asker)
            .HasForeignKey(x => x.AskerId)
            .IsRequired(false);
        
        builder
            .HasMany(x => x.GroupResponder)
            .WithOne(x => x.Responder)
            .HasForeignKey(x => x.ResponderId)
            .IsRequired(false);*/
    }
}