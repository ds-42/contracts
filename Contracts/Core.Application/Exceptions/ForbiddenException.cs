using System.Net;

namespace Core.Application.Exceptions;

public class ForbiddenException : CustomException
{
    public ForbiddenException() : base("Forbidden", HttpStatusCode.Forbidden)
    {
    }
}

