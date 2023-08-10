using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.GameRooms.Contracts;

namespace MultiplayerGame.Application.GameRooms.Commands.CreateGameRoomCommand
{
    public sealed record CreateGameRoomCommand(
        string Nickname,
        string Color) : Operation<GameRoomDto>;
}
