namespace Bz.F8t.Administration.Application.Common.Exceptions;

public class ValidationException : Exception
{
    private readonly IEnumerable<ValidationError> _errors;

    public ValidationException() { }

    public ValidationException(IEnumerable<ValidationError> errors) 
    { 
        _errors = errors;
    }

    public ValidationException(string message) : base(message) { }

    public ValidationException(string message, Exception inner) : base(message, inner) { }
}
