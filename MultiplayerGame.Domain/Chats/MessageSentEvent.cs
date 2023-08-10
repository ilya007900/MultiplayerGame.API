using MultiplayerGame.Domain.Common;

namespace MultiplayerGame.Domain.Chats
{
    public sealed record MessageSentEvent(Guid ChatId, Message Message) : DomainEvent;
}
