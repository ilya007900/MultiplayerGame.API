using MultiplayerGame.Domain.Games;

namespace MultiplayerGame.Infrastructure.Database.Repositories
{
    public class MovementRepository : Repository<Movement, int>, IMovementRepository
    {
        public MovementRepository(MultiplayerGameDbContext dbContext) : base(dbContext)
        {

        }
    }
}
