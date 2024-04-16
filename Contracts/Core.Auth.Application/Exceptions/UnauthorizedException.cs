using Core.Application.Exceptions;
using System.Net;

namespace Core.Auth.Application.Exceptions;

public class UnauthorizedException : BaseException
{
    public UnauthorizedException() : base(new { Message = "Unauthorized" }, HttpStatusCode.Unauthorized)
    {
    }
}
