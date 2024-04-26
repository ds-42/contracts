using Core.Auth.Application.Abstractions.Service;
using Core.Users.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Core.Auth.Api;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    /**lai    public int UserId => int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        public string[] UserRoles => _httpContextAccessor.HttpContext.User.Claims
            .Where(t => t.Type == ClaimTypes.Role)
            .Select(t => t.Value)
            .ToArray();**/

    public bool IsAdmin => throw new NotImplementedException();

    public int CurrentUserId => throw new NotImplementedException();

    public int CurrentOrgId => throw new NotImplementedException();

    public UserRole CurrentUserRole => throw new NotImplementedException();
}
