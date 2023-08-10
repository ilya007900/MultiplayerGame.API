using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.Games.Contracts;

namespace MultiplayerGame.Application.Games.Commands.StartGameCommand
{
    public sealed record StartGameCommand(
        Guid GameRoomId,
        int FieldWidth,
        int FieldHeight,
        int GameUnitWidth,
        int GameUnitHeight) : Operation<GameDto>;
}
