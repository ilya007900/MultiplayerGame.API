using MediatR;
using Microsoft.Extensions.Logging;

namespace MultiplayerGame.Infrastructure.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestId = Guid.NewGuid();
            _logger.LogInformation("Processing request: {requestId}, type: {requestType}, data: {request}", requestId, request.GetType(), request);

            var response = await next();

            _logger.LogInformation("Processed request: {requestId}", requestId);

            return response;
        }
    }
}
