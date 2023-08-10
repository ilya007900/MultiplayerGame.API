using CSharpFunctionalExtensions;

namespace MultiplayerGame.Domain.SharedKernel
{
    public class Player : ValueObject
    {
        public string Nickname { get; }

        public string Color { get; }

        private Player(string nickname, string color)
        {
            Nickname = nickname;
            Color = color;
        }

        public static Player Create(string nickname, string color)
        {
            return new Player(nickname, color);
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Nickname;
        }
    }
}
