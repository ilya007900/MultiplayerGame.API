using CSharpFunctionalExtensions;
using MultiplayerGame.Domain.Common;
using MultiplayerGame.Domain.Games;
using MultiplayerGame.Domain.SharedKernel;

namespace MultiplayerGame.Domain.GameRooms
{
    public class GameRoom : AggregateRoot
    {
        private readonly List<Player> _players = new();

        public IReadOnlyList<Player> Players => _players.AsReadOnly();

        private GameRoom()
        {

        }

        private GameRoom(Guid id, List<Player> players)
        {
            Id = id;
            _players = players;
        }

        public static GameRoom Create(Player player)
        {
            return new GameRoom(
                Guid.NewGuid(),
                new List<Player> { player });
        }

        public Result Join(Player player)
        {
            if (Players.Contains(player))
            {
                return Result.Failure("Player already joined.");
            }

            if (Players.Any(x => x.Color == player.Color))
            {
                return Result.Failure("Player with same color already exists");
            }

            _players.Add(player);

            AddDomainEvent(new PlayerJoinedGameRoomEvent(Id, player));

            return Result.Success();
        }

        public Result<Player> Leave(string nickname)
        {
            var player = Players.SingleOrDefault(x => x.Nickname == nickname);
            if (player == null)
            {
                return Result.Failure<Player>($"No player found with nickname {nickname}.");
            }

            _players.Remove(player);

            AddDomainEvent(new PlayerLeftGameRoomEvent(Id, player));

            return player;
        }

        public Game StartGame(Area fieldSize, Area gameUnitSize)
        {
            var game = Game.Create(Players, fieldSize, gameUnitSize);
            game.Start(this);

            return game;
        }
    }
}
