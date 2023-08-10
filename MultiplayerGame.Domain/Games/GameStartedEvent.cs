using MultiplayerGame.Domain.Common;

namespace MultiplayerGame.Domain.Games
{
    public record GameStartedEvent(
        Guid GameRoomId,
        Guid GameId) : DomainEvent;
}
