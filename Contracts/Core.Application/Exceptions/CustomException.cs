using System.Net;

namespace Core.Application.Exceptions;

public class CustomException : BaseException
{
    public CustomException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : 
        base(new { Message = message }, statusCode)
    {
    }
}
