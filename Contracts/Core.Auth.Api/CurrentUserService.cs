using Core.Application.Exceptions;
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

    public bool IsAdmin => CurrentUserRole == ApplicationUserRolesEnum.Admin;

    public int Id
    {
        get
        {
//            return 1;
            var val = _httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            return int.Parse(val);
        }
    }

    public int OrgId
    {
        get
        {
  //          return 1;
            var val = _httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.UserData)!.Value;
            return int.Parse(val);
        }
    }

    /*
        protected int OrganizationId { get {
                var orgId = HttpContext.Request.Headers["OrganizationId"];
    /*            org.ToString();
                foreach (var header in HttpContext.Request.Headers)
                {
                    header.Value
                    stringBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
                }
                HttpContext.
                HttpContext.Request.Headers.TryGetValue("OrganizationId", out StringValues headerValue);
                headerValue.

                    var id = HttpContext.Request.Headers["OrganizationId"];
            return 0;

        } }

     */

    public ApplicationUserRolesEnum CurrentUserRole
    {
        get
        {
            return Id switch
            {
                1 => ApplicationUserRolesEnum.Admin,
                _ => ApplicationUserRolesEnum.Client,
            };
        }
    }

    public void TestAccess()
    {
        if (!IsAdmin)
            throw new AccessDeniedException();
    }

}
