using MultiplayerGame.Domain.Games;

namespace MultiplayerGame.Infrastructure.Database.Repositories
{
    public class GameRepository : Repository<Game, Guid>, IGameRepository
    {
        public GameRepository(MultiplayerGameDbContext dbContext) : base(dbContext)
        {

        }
    }
}
