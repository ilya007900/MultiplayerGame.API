using CSharpFunctionalExtensions;
using MultiplayerGame.Domain.Chats;
using MultiplayerGame.Domain.Common;
using MultiplayerGame.Domain.GameRooms;
using MultiplayerGame.Domain.SharedKernel;

namespace MultiplayerGame.Domain.Games
{
    public class Game : AggregateRoot
    {
        private readonly List<GameUnit> _gameUnits = new();
        private string _currentTurnPlayerNickname;

        public IReadOnlyList<Player> Players => _gameUnits.Select(x => x.Player).ToArray();

        public IReadOnlyList<GameUnit> GameUnits => _gameUnits.AsReadOnly();

        public Area FieldSize { get; private set; }

        public Area GameUnitSize { get; private set; }

        public Player CurrentTurn => Players.Single(x => x.Nickname == _currentTurnPlayerNickname);

        public Guid? ChatId { get; private set; } = null;
        
        #region EntityFramework
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Game()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
        #endregion

        private Game(
            Guid id,
            Area fieldSize,
            Area gameUnitSize,
            IEnumerable<GameUnit> gameUnits,
            string currentTurnPlayerNickname)
        {
            Id = id;
            FieldSize = fieldSize;
            GameUnitSize = gameUnitSize;
            _gameUnits.AddRange(gameUnits);
            _currentTurnPlayerNickname = currentTurnPlayerNickname;
        }

        public static Game Create(
            IEnumerable<Player> players,
            Area fieldSize,
            Area gameUnitSize)
        {
            var gameUnits = new List<GameUnit>();
            foreach (var player in players)
            {
                var x = gameUnits.Count + 1 + (gameUnitSize.Width * gameUnits.Count);
                var y = gameUnits.Count + 1 + (gameUnitSize.Height * gameUnits.Count);
                var position = new Position(x, y);

                var gameUnit = new GameUnit(player, position);
                gameUnits.Add(gameUnit);
            }

            return new Game(Guid.NewGuid(), fieldSize, gameUnitSize, gameUnits, players.First().Nickname);
        }

        public void Start(GameRoom gameRoom)
        {
            AddDomainEvent(new GameStartedEvent(gameRoom.Id, Id));
        }

        public Chat StartChat()
        {
            var chat = Chat.Create();
            ChatId = chat.Id;
            return chat;
        }

        public Result MakeMove(string nickname, Position newPosition)
        {
            var gameUnit = GameUnits.SingleOrDefault(x => x.Player.Nickname == nickname);
            if (gameUnit == null)
            {
                return Result.Failure($"No player with nickname {nickname}.");
            }

            if (CurrentTurn.Nickname != nickname)
            {
                return Result.Failure("Not your turn.");
            }

            var nextTurnPlayer = GetNextTurnPlayer();
            _currentTurnPlayerNickname = nextTurnPlayer.Nickname;

            var oldPosition = gameUnit.Position;

            gameUnit.UpdatePosition(newPosition);

            AddDomainEvent(new MoveMadeEvent(Id, gameUnit, oldPosition, nextTurnPlayer));
            return Result.Success();
        }

        private Player GetNextTurnPlayer()
        {
            for (var i = 0; i < Players.Count - 1; i++)
            {
                if (Players[i] == CurrentTurn)
                {
                    return Players[i + 1];
                }
            }

            return Players[0];
        }
    }
}
