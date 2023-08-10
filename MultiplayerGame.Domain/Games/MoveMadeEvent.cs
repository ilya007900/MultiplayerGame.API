using MultiplayerGame.Domain.Common;
using MultiplayerGame.Domain.SharedKernel;

namespace MultiplayerGame.Domain.Games
{
    public sealed record MoveMadeEvent(
        Guid GameId,
        GameUnit GameUnit,
        Position OldPosition,
        Player NextMove) : DomainEvent;
}
