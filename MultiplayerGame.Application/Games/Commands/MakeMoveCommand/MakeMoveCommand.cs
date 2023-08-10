using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.Games.Contracts;

namespace MultiplayerGame.Application.Games.Commands.MakeMoveCommand
{
    public sealed record MakeMoveCommand(
        Guid GameId,
        string PlayerNickname,
        PositionDto NewPosition) : Operation<GameDto>;
}
