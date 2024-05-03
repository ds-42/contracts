using System.Net;

namespace Core.Application.Exceptions;

public class NotFoundException : CustomException
{
    public NotFoundException(string message) : base(message, HttpStatusCode.Forbidden)
    {
    }
}


