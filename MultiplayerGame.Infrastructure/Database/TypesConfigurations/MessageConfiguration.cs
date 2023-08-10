using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiplayerGame.Domain.Chats;

namespace MultiplayerGame.Infrastructure.Database.TypesConfigurations
{
    internal class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages", MultiplayerGameDbContext.DefaultSchema);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.HasOne<Chat>().WithMany(x => x.Messages);
        }
    }
}
