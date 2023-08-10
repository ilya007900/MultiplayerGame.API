namespace MultiplayerGame.Domain.Games
{
    public class Area
    {
        public int Width { get; }

        public int Height { get; }

        public Area(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
