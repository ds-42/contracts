using System.Reflection;
using Core.Application.Exceptions;
using Core.Auth.Application.Abstractions.Service;
using Core.Auth.Application.Attributes;
using Core.Auth.Application.Exceptions;
using MediatR;

namespace Core.Auth.Application.Behavior;

public class AuthorizePermissionsBehavior<TRequest, TResponse>(ICurrentUserService currentUserService)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (request.GetType().GetCustomAttribute(typeof(RequestAuthorizeAttribute), true) is not RequestAuthorizeAttribute requestAuthorizeAttribute)
        {
            return next();
        }

        if (currentUserService.CurrentUserId == 0) throw new UnauthorizedException();

        if (requestAuthorizeAttribute.Role is null)
        {
            return next();
        }

        if (currentUserService.CurrentUserRole == 0)
        {
            throw new ForbiddenException();
        }

        var requiredRole = requestAuthorizeAttribute.Role;
        if (requiredRole == 0)
        {
            return next();
        }
        
/*        if (requiredRole .Any(rn => currentUserService.CurrentUserRoles.All(role => role != rn)))
        {
            throw new ForbiddenException();
        }*/

        return next();
    }
}