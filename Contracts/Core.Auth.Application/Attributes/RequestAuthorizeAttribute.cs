using Core.Users.Domain.Enums;

namespace Core.Auth.Application.Attributes;

public class RequestAuthorizeAttribute(ApplicationUserRolesEnum? role = null) : Attribute
{
    public ApplicationUserRolesEnum? Role { get; } = role;
}
