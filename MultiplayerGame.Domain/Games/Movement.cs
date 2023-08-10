using CSharpFunctionalExtensions;

namespace MultiplayerGame.Domain.Games
{
    public class Movement : Entity<int>
    {
        public Guid GameId { get; private set; }

        public string PlayerNickname { get; private set; }

        public Position OldPosition { get; private set; }

        public Position NewPosition { get; private set; }

        #region EntityFramework
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Movement()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            
        }
        #endregion

        public Movement(Guid gameId, string playerNickname, Position oldPosition, Position newPosition)
        {
            GameId = gameId;
            PlayerNickname = playerNickname;
            OldPosition = oldPosition;
            NewPosition = newPosition;
        }
    }
}
