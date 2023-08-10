using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.GameRooms.Contracts;

namespace MultiplayerGame.Application.GameRooms.Commands.JoinGameRoomCommand
{
    public sealed record JoinGameRoomCommand(
        Guid GameRoomId,
        string Nickname,
        string Color) : Operation<GameRoomDto>;
}
