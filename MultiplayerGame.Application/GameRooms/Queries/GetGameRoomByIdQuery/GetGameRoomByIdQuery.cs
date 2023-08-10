using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.GameRooms.Contracts;

namespace MultiplayerGame.Application.GameRooms.Queries.GetGameRoomByIdQuery
{
    public sealed record GetGameRoomByIdQuery(
        Guid Id) : Operation<GameRoomDto>;
}
