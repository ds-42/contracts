using Core.Users.Domain.Enums;

namespace Core.Auth.Application.Abstractions.Service;

public interface ICurrentUserService
{
    public int Id { get; }
    public ApplicationUserRolesEnum CurrentUserRole { get; }
    public bool IsAdmin { get; }
    public void TestAccess();
}