using MediatR;

namespace MultiplayerGame.Application.Base
{
    public record Operation<TResult>() : IRequest<OperationResult<TResult>>;
}
