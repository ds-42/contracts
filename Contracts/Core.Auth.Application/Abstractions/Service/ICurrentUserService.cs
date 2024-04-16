using Core.Users.Domain.Enums;

namespace Core.Auth.Application.Abstractions.Service;

public interface ICurrentUserService
{
    public int CurrentUserId { get; }
    public int CurrentOrgId { get; }
    
    public UserRole CurrentUserRole { get; }
    public bool IsAdmin { get; }
}