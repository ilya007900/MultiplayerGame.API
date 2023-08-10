using FluentValidation;
using MediatR;
using MultiplayerGame.Application.Base;

namespace MultiplayerGame.Infrastructure.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse: OperationResult
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var errors = _validators
                .Select(validator => validator.Validate(request))
                .SelectMany(validationResult => validationResult.Errors)
                .Where(error => error != null)
                .ToArray();

            if (errors.Any())
            {
                var validationErrors = errors
                    .Select(x => new ValidationError(x.PropertyName, x.ErrorMessage))
                    .ToArray();

                return (TResponse)Activator.CreateInstance(typeof(TResponse), validationErrors.AsEnumerable())!;
            }

            return await next();
        }
    }
}
