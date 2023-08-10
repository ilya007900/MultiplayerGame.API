using MultiplayerGame.Domain.Games;

namespace MultiplayerGame.Application.Games.Contracts
{
    public static class Mapper
    {
        public static GameDto From(Game game)
        {
            return new GameDto(
                game.Id,
                game.Players.Select(Shared.DataContracts.Mapper.From).ToArray(),
                game.GameUnits.Select(From).ToArray(),
                Shared.DataContracts.Mapper.From(game.CurrentTurn),
                From(game.FieldSize),
                From(game.GameUnitSize),
                game.ChatId);
        }

        public static GameUnitDto From(GameUnit gameUnit)
        {
            return new GameUnitDto(
                Shared.DataContracts.Mapper.From(gameUnit.Player),
                From(gameUnit.Position));
        }

        public static PositionDto From(Position position)
        {
            return new PositionDto(position.X, position.Y);
        }

        public static AreaDto From(Area rectangle)
        {
            return new AreaDto(rectangle.Width, rectangle.Height);
        }
    }
}
