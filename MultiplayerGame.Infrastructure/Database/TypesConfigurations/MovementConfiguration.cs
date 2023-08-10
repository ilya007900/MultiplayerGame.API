using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiplayerGame.Domain.Games;

namespace MultiplayerGame.Infrastructure.Database.TypesConfigurations
{
    internal class MovementConfiguration : IEntityTypeConfiguration<Movement>
    {
        public void Configure(EntityTypeBuilder<Movement> builder)
        {
            builder.ToTable("MovementsLog", MultiplayerGameDbContext.LogSchema);

            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.OldPosition, o =>
            {
                o.Property(x => x.X).HasColumnName("OldXPosition");
                o.Property(x => x.Y).HasColumnName("OldYPosition");
            });

            builder.OwnsOne(x => x.NewPosition, o =>
            {
                o.Property(x => x.X).HasColumnName("NewXPosition");
                o.Property(x => x.Y).HasColumnName("NewYPosition");
            });
        }
    }
}
