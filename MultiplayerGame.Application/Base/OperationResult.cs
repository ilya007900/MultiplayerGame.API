namespace MultiplayerGame.Application.Base
{
    public sealed record ValidationError(string PropertyName, string Error);

    public class OperationResult
    {
        private readonly List<ValidationError> _errors = new();

        public bool Success { get; }

        public bool Failure => !Success;

        public IReadOnlyList<ValidationError> Errors => 
            Failure ? _errors.AsReadOnly() : throw new InvalidOperationException("No errors.");

        public OperationResult()
        {
            Success = true;
        }

        public OperationResult(IEnumerable<ValidationError> errors)
        {
            Success = false;
            _errors.AddRange(errors);
        }
    }

    public sealed class OperationResult<TResult> : OperationResult
    {
        public TResult Result { get; }

        public OperationResult(TResult result) : base()
        {
            Result = result;
        }

        public OperationResult(IEnumerable<ValidationError> errors) : base(errors)
        {
            Result = default!;
        }
    }

    public static class OperationResultFactory
    {
        public static OperationResult<TResult> CreateFailure<TResult>(string message)
        {
            return CreateFailure<TResult>(string.Empty, message);
        }

        public static OperationResult<TResult> CreateFailure<TResult>(string propertyName, string message)
        {
            var errors = new ValidationError[] { new ValidationError(propertyName, message) };
            return new OperationResult<TResult>(errors);
        }

        public static OperationResult<TResult> CreateSucess<TResult>(TResult result)
        {
            return new OperationResult<TResult>(result);
        }
    }
}
