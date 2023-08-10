using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MultiplayerGame.Infrastructure.Database
{
    public class MultiplayerGameDbContext : DbContext
    {
        public const string DefaultSchema = "dbo";
        public const string LogSchema = "log";

        public MultiplayerGameDbContext(DbContextOptions<MultiplayerGameDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
