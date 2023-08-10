using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.Chats.Contracts;

namespace MultiplayerGame.Application.Chats.Queries.GetByIdQuery
{
    public sealed record GetByIdQuery(Guid ChatId) : Operation<ChatDto>;
}
