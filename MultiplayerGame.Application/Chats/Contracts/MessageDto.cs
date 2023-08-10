namespace MultiplayerGame.Application.Chats.Contracts
{
    public sealed record MessageDto(
        Guid Id,
        string From,
        string Text,
        DateTimeOffset SentDateTime);
}
