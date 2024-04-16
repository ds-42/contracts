using System.Net;
using System.Text.Json;
using Core.Application.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Core.Auth.Application.Middlewares;

internal class AuthorizationExceptionsHandlerMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            switch (e)
            {
                case BaseException baseException:
                    await baseException.WriteAsync(context);
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    await context.Response.WriteAsync(JsonSerializer.Serialize(new 
                    {
                        error = e.Message,
                        innerMessage = e.InnerException?.Message,
                        e.StackTrace,
                    }));
                    break;
            }
        }
    }
}

public static class AuthorizationExceptionsHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseAuthExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AuthorizationExceptionsHandlerMiddleware>();
    }
}