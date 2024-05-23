using System.Net;

namespace Core.Application.Exceptions;

public class UsedAnotherTableException : BaseException
{
    public UsedAnotherTableException() :
        base(new { Message = $"Used by another table" }, HttpStatusCode.Forbidden)
    {
    }
}
