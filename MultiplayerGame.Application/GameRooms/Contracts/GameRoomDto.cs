using MultiplayerGame.Application.Shared.DataContracts;

namespace MultiplayerGame.Application.GameRooms.Contracts
{
    public sealed record GameRoomDto(Guid Id, IReadOnlyList<PlayerDto> Players);
}
