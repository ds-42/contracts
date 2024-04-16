using System.Net;

namespace Core.Application.Exceptions;

public class AccessDeniedException : BaseException
{
    public AccessDeniedException() : base(new { Message = "Access denied" }, HttpStatusCode.Forbidden)
    {
    }
}

