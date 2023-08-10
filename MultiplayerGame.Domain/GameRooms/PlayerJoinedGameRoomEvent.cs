using MultiplayerGame.Domain.Common;
using MultiplayerGame.Domain.SharedKernel;

namespace MultiplayerGame.Domain.GameRooms
{
    public sealed record PlayerJoinedGameRoomEvent(
        Guid GameRoomId,
        Player Player) : DomainEvent;
}
