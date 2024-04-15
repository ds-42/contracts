namespace Core.Auth.Application.Abstractions.Service;

public interface ICurrentUserService
{
    public int CurrentUserId { get; }
    public int CurrentOrgId { get; }
    
//    public ApplicationUserRolesEnum[] CurrentUserRoles { get; }

//    public bool UserInRole(ApplicationUserRolesEnum role);
}