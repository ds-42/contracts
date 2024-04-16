using System.Net;

namespace Core.Application.Exceptions;

public class BadRequestException : BaseException
{
    public BadRequestException(string error) : base(error, HttpStatusCode.BadRequest)
    {
    }
}
