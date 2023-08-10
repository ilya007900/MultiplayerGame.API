using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.GameRooms.Contracts;

namespace MultiplayerGame.Application.GameRooms.Commands.LeaveGameRoomCommand
{
    public sealed record LeaveGameRoomCommand(Guid GameRoomId, string Nickname) :
        Operation<GameRoomDto>;
}
