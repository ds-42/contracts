using System.Net;
using Core.Application.Exceptions;
using Core.Application.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Core.Api.Middlewares;

internal class CoreExceptionsHandlerMiddleware(RequestDelegate next)
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

                    await context.Response.WriteAsync((new
                    {
                        error = e.Message,
                        innerMessage = e.InnerException?.Message,
                        e.StackTrace,
                    }).JsonSerialize());
                    break;
            }
        }
    }
}

public static class CoreExceptionsHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseCoreExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CoreExceptionsHandlerMiddleware>();
    }
}