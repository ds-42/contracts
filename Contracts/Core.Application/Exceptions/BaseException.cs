using Core.Application.Extensions;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Core.Application.Exceptions;

public class BaseException : Exception
{
    public readonly HttpStatusCode StatusCode;

    public BaseException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message)
    {
        StatusCode = statusCode;
    }

    public BaseException(object item, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) :
        this(item.JsonSerialize(), statusCode)
    {
    }

    public virtual async Task WriteAsync(HttpContext httpContext)
    {
        httpContext.Response.StatusCode = (int)StatusCode;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsync(Message);
    }
}
