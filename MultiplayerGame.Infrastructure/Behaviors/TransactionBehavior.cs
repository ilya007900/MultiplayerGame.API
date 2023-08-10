using MediatR;
using MultiplayerGame.Application.Base;
using MultiplayerGame.Domain.Common;
using MultiplayerGame.Infrastructure.Database;

namespace MultiplayerGame.Infrastructure.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : OperationResult
    {
        private readonly MultiplayerGameDbContext _dbContext;
        private readonly IMediator _mediator;

        public TransactionBehavior(MultiplayerGameDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next();

            if (response.Failure)
            {
                return response;
            }

            var aggregates = _dbContext.ChangeTracker
                .Entries<AggregateRoot>()
                .Select(x => x.Entity)
                .ToArray();

            var domainEvents = aggregates
                .SelectMany(x => x.DomainEvents)
                .ToArray();

            foreach (var aggregate in aggregates)
            {
                aggregate.ClearDomainEvents();
            }

            await _dbContext.SaveChangesAsync(CancellationToken.None);

            foreach (var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent, CancellationToken.None);
            }

            return response;
        }
    }
}
