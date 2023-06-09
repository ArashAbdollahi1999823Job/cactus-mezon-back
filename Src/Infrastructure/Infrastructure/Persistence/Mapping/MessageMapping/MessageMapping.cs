using Domain.Entities.ChatEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Mapping.MessageMapping;

public class MessageMapping:IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Asker)
            .WithMany(x => x.MessagesSent)
            .HasForeignKey(x=>x.AskerId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        builder.HasOne(x => x.Responder)
            .WithMany(x => x.MessagesReceived)
            .HasForeignKey(x=>x.ResponderId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        builder.HasOne(x => x.Group)
            .WithMany(x => x.Messages)
            .HasForeignKey(x=>x.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}