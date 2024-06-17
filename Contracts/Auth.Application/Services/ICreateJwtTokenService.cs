using Core.Users.Domain;

namespace Auth.Application.Services;

public interface ICreateJwtTokenService
{
    string CreateJwtToken(int OrgId, User user, DateTime dateExpires);
}