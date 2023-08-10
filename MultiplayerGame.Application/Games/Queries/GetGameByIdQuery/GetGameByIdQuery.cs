using MultiplayerGame.Application.Base;
using MultiplayerGame.Application.Games.Contracts;

namespace MultiplayerGame.Application.Games.Queries.GetGameByIdQuery
{
    public sealed record GetGameByIdQuery(Guid Id) : Operation<GameDto>;
}
