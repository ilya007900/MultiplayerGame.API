using MultiplayerGame.Application.Shared.DataContracts;

namespace MultiplayerGame.Application.Games.Contracts
{
    public sealed record GameUnitDto(PlayerDto Player, PositionDto Position);
}
