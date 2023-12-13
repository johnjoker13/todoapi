namespace Application.Common;

public class InvalidCredentialsException : Exception
{
    public InvalidCredentialsException() : base() { }

    public InvalidCredentialsException(string message) : base(message) { }

    public InvalidCredentialsException(string message, Exception inner) : base(message, inner)
    {
    }
}