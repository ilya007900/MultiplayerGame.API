namespace MultiplayerGame.Application.Chats.Contracts
{
    public sealed record ChatDto(
        Guid Id,
        IReadOnlyList<MessageDto> Messages);
}
