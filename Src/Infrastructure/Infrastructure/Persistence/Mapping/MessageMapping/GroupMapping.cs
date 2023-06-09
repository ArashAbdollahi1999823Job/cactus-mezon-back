using Domain.Entities.ChatEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Mapping.MessageMapping;

public class GroupMapping:IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasOne(x => x.Asker)
            .WithMany(x => x.GroupAsker)
            .HasForeignKey(x => x.AskerId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .IsRequired(false);

        builder.HasOne(x => x.Responder)
            .WithMany(x => x.GroupResponder)
            .HasForeignKey(x => x.ResponderId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .IsRequired(false);

        builder.HasMany(x => x.Messages)
            .WithOne(x => x.Group)
            .HasForeignKey(x => x.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}