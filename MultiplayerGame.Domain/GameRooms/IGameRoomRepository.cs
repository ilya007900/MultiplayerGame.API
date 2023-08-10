using MultiplayerGame.Domain.Common;

namespace MultiplayerGame.Domain.GameRooms
{
    public interface IGameRoomRepository : IRepository<GameRoom, Guid>
    {
    }
}
