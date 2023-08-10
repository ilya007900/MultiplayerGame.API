using MultiplayerGame.Domain.SharedKernel;

namespace MultiplayerGame.Domain.Games
{
    public class GameUnit
    {
        public Player Player { get; }
        
        public Position Position { get; private set; }

        #region EntityFramework
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private GameUnit()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            
        }
        #endregion

        public GameUnit(Player player, Position position)
        {
            Player = player;
            Position = position;
        }

        public void UpdatePosition(Position newPosition)
        {
            Position = newPosition;
        }
    }
}
