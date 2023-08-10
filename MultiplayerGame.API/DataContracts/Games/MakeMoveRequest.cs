using MultiplayerGame.Application.Games.Contracts;

namespace MultiplayerGame.API.DataContracts.Games
{
    public sealed record MakeMoveRequest( string Nickname, PositionDto NewPosition);
}
