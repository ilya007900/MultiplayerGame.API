using MultiplayerGame.Domain.GameRooms;

namespace MultiplayerGame.Infrastructure.Database.Repositories
{
    public class GameRoomRepository : Repository<GameRoom, Guid>, IGameRoomRepository
    {
        public GameRoomRepository(MultiplayerGameDbContext dbContext) : base(dbContext)
        {
        }
    }
}
