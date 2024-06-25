using System.Net;

namespace Core.Application.Exceptions;

public class BadOperationException : CustomException
{
    public BadOperationException(string? error) : base(error ?? "", HttpStatusCode.BadRequest)
    {
    }
}
