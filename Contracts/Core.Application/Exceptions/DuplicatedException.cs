using System.Net;

namespace Core.Application.Exceptions;

public class DuplicatedException<T> : BaseException
{
    public DuplicatedException() :
        base(new { Message = $"Duplicated {typeof(T).Name}" }, HttpStatusCode.BadRequest)
    {
    }
}
