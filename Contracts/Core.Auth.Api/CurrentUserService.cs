using Core.Auth.Application.Abstractions.Service;
using Core.Users.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
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

    public int Id 
    {
        get 
        {
            return 1;
            var val = _httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            return int.Parse(val);
        }
    }

    public ApplicationUserRolesEnum CurrentUserRole => throw new NotImplementedException();
}
