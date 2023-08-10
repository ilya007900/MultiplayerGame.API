using MultiplayerGame.Domain.Common;

namespace MultiplayerGame.Domain.Games
{
    public interface IGameRepository : IRepository<Game, Guid>
    {
    }
}
