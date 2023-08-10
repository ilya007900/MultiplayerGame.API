using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiplayerGame.Domain.GameRooms;

namespace MultiplayerGame.Infrastructure.Database.TypesConfigurations
{
    internal class GameRoomConfiguration : IEntityTypeConfiguration<GameRoom>
    {
        public void Configure(EntityTypeBuilder<GameRoom> builder)
        {
            builder.ToTable("GameRooms", MultiplayerGameDbContext.DefaultSchema);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id");

            builder.OwnsMany(x => x.Players, o =>
            {
                o.WithOwner().HasForeignKey("GameRoomId");
                o.Property<int>("Id");
                o.Property(x => x.Nickname).HasColumnName("Nickname");
                o.Property(x => x.Color).HasColumnName("Color");
                o.HasKey("Id");
            });

            builder.Ignore(x => x.DomainEvents);
        }
    }
}
