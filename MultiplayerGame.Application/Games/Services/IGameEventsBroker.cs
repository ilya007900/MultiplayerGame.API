using MultiplayerGame.Domain.Games;
using MultiplayerGame.Domain.SharedKernel;

namespace MultiplayerGame.Application.Games.Services
{
    public interface IGameEventsBroker
    {
        Task NotifyMoveMade(Guid gameId, GameUnit gameUnit, Player NextMove);
    }
}
