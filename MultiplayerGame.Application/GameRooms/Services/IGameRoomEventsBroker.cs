using MultiplayerGame.Domain.SharedKernel;

namespace MultiplayerGame.Application.GameRooms.Services
{
    public interface IGameRoomEventsBroker
    {
        Task NotifyPlayerJoined(Guid gameRoomId, Player player);

        Task NotifyPlayerLeft(Guid gameRoomId, Player player);

        Task NotifyGameStarted(Guid gameRoomId, Guid gameId);
    }
}
