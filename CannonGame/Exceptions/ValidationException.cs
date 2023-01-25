namespace CannonGame.Exceptions;

public class ValidationException : Exception
{
    public override string Message { get; }

    public ValidationException(string message) => Message = message;
    
}
