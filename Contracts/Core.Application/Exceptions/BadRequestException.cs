using System.Net;

namespace Core.Application.Exceptions;

public class BadRequestException : CustomException
{
    public BadRequestException(string error) : base(error, HttpStatusCode.BadRequest)
    {
    }
}
