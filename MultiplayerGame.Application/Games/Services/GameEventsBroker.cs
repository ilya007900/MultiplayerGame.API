using Microsoft.AspNetCore.SignalR;
using MultiplayerGame.Domain.Games;
using MultiplayerGame.Domain.SharedKernel;

namespace MultiplayerGame.Application.Games.Services
{
    public class GameEventsBroker : IGameEventsBroker
    {
        private readonly IHubContext<GameHub> _gameHub;

        public GameEventsBroker(IHubContext<GameHub> gameHub)
        {
            _gameHub = gameHub;
        }

        public async Task NotifyMoveMade(Guid gameId, GameUnit gameUnit, Player nextMove)
        {
            await _gameHub.Clients.All.SendAsync($"move-made-{gameId}", gameUnit, nextMove);
        }
    }
}
