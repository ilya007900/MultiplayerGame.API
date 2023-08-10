using MultiplayerGame.Domain.GameRooms;

namespace MultiplayerGame.Application.GameRooms.Contracts
{
    public static class Mapper
    {
        public static GameRoomDto From(GameRoom gameRoom)
        {
            return new GameRoomDto(
                gameRoom.Id,
                gameRoom.Players.Select(Shared.DataContracts.Mapper.From).ToArray());
        }
    }
}
