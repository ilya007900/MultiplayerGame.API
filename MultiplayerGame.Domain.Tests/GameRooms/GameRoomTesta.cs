using FluentAssertions;
using MultiplayerGame.Domain.GameRooms;
using MultiplayerGame.Domain.SharedKernel;

namespace MultiplayerGame.Domain.Tests.GameRooms
{
    public class GameRoomTesta
    {
        [Fact]
        public void CanNotJoinRoomIfThereArePlayerWithSameNickname()
        {
            var player1 = Player.Create("Player1", "#ffffff");
            var player2 = Player.Create("Player1", "#000000");
            var gameRoom = GameRoom.Create(player1);
            
            var result = gameRoom.Join(player2);

            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void CanNotJoinRoomIfThereArePlayerWithSameColor()
        {
            var player1 = Player.Create("Player1", "#ffffff");
            var player2 = Player.Create("Player2", "#ffffff");
            var gameRoom = GameRoom.Create(player1);

            var result = gameRoom.Join(player2);

            result.IsSuccess.Should().BeFalse();
        }
    }
}
