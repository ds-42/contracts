using System.Net;

namespace Core.Application.Exceptions;

public class ForbiddenException : BaseException
{
    public ForbiddenException() : base(new { Message = "Forbidden" }, HttpStatusCode.Forbidden)
    {
    }
}

