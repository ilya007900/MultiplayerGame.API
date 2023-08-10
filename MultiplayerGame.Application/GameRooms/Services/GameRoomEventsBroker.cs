using Microsoft.AspNetCore.SignalR;
using MultiplayerGame.Domain.SharedKernel;

namespace MultiplayerGame.Application.GameRooms.Services
{
    public class GameRoomEventsBroker : IGameRoomEventsBroker
    {
        private readonly IHubContext<GameRoomHub> _gameRoomHub;

        public GameRoomEventsBroker(IHubContext<GameRoomHub> gameRoomHub)
        {
            _gameRoomHub = gameRoomHub;
        }

        public async Task NotifyPlayerJoined(Guid gameRoomId, Player player)
        {
            await _gameRoomHub.Clients.All
                .SendAsync($"player-joined-{gameRoomId}", player);
        }

        public async Task NotifyPlayerLeft(Guid gameRoomId, Player player)
        {
            await _gameRoomHub.Clients.All
                .SendAsync($"player-left-{gameRoomId}", player);
        }

        public async Task NotifyGameStarted(Guid gameRoomId, Guid gameId)
        {
            await _gameRoomHub.Clients.All.SendAsync($"game-started-{gameRoomId}", gameId);
        }
    }
}
