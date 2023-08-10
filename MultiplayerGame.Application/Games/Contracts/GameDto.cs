using MultiplayerGame.Application.Shared.DataContracts;

namespace MultiplayerGame.Application.Games.Contracts
{
    public sealed record GameDto(
        Guid Id,
        IReadOnlyList<PlayerDto> Players,
        IReadOnlyList<GameUnitDto> GameUnits,
        PlayerDto CurrentTurn,
        AreaDto FieldSize,
        AreaDto GameUnitSize,
        Guid? ChatId);
}
