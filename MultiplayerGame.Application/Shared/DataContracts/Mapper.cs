using MultiplayerGame.Domain.SharedKernel;

namespace MultiplayerGame.Application.Shared.DataContracts
{
    public static class Mapper
    {
        public static PlayerDto From(Player player)
        {
            return new PlayerDto(player.Nickname, player.Color);
        }
    }
}
