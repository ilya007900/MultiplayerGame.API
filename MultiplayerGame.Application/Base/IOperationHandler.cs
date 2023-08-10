using MediatR;

namespace MultiplayerGame.Application.Base
{
    public interface IOperationHandler<TOperation, TResult> :
        IRequestHandler<TOperation, OperationResult<TResult>> where TOperation : Operation<TResult>
    {
    }
}
