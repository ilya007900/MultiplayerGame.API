using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.Chats.Contracts;

namespace MultiplayerGame.Application.Chats.Commands.SendMessageCommand
{
    public sealed record SendMessageCommand(
        Guid ChatId,
        string From,
        string Text) : Operation<ChatDto>;
}
