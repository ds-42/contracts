using Core.Users.Domain.Enums;

namespace Core.Auth.Application.Attributes;

public class RequestAuthorizeAttribute(UserRole? role = null) : Attribute
{
    public UserRole? Role { get; } = role;
}
