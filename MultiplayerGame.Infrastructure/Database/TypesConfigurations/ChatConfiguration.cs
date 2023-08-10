using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiplayerGame.Domain.Chats;

namespace MultiplayerGame.Infrastructure.Database.TypesConfigurations
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.ToTable("Chats", MultiplayerGameDbContext.DefaultSchema);

            builder.HasKey(x => x.Id);
            
            builder.HasMany(x => x.Messages).WithOne();

            builder.Navigation(x => x.Messages).AutoInclude();

            builder.Ignore(x => x.DomainEvents);
        }
    }
}
