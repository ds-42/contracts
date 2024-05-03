using System.Net;

namespace Core.Application.Exceptions;

public class AccessDeniedException : CustomException
{
    public AccessDeniedException() : base("Access denied", HttpStatusCode.Forbidden)
    {
    }
}

