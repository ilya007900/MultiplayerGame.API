using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiplayerGame.Domain.Games;

namespace MultiplayerGame.Infrastructure.Database.TypesConfigurations
{
    internal class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Games", MultiplayerGameDbContext.DefaultSchema);

            builder.HasKey(x => x.Id);

            builder.Property<string>("_currentTurnPlayerNickname");

            builder.OwnsMany(x => x.GameUnits, o =>
            {
                o.WithOwner().HasForeignKey("GameId");
                o.Property<int>("Id");
                o.OwnsOne(u => u.Player, po =>
                {
                    po.Property(x => x.Nickname).HasColumnName("PlayerNickname");
                    po.Property(x => x.Color).HasColumnName("PlayerColor");
                });
                o.OwnsOne(u => u.Position, pp =>
                {
                    pp.Property(x => x.X).HasColumnName("PositionX");
                    pp.Property(x => x.Y).HasColumnName("PositionY");
                });
                o.HasKey("Id");
            });

            builder.OwnsOne(x => x.FieldSize, o =>
            {
                o.Property(x => x.Height).HasColumnName("FieldHeight");
                o.Property(x => x.Width).HasColumnName("FieldWidth");
            });

            builder.OwnsOne(x => x.GameUnitSize, o =>
            {
                o.Property(x => x.Height).HasColumnName("GameUnitHeight");
                o.Property(x => x.Width).HasColumnName("GameUnitWidth");
            });

            builder.Ignore(x => x.Players);
            builder.Ignore(x => x.CurrentTurn);
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
