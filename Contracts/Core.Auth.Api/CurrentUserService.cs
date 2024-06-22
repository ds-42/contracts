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
//            return 1;
            var val = _httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.UserData)!.Value;
            return int.Parse(val);
        }
    }

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
