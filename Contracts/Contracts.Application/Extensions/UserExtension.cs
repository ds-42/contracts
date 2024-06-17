using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Exceptions;
using Core.Users.Domain;

namespace Contracts.Application.Extensions;

public static class UserExtension
{
    public static async Task<User?> FindItem(this IBaseReadRepository<User> users, int Id, CancellationToken cancellationToken)
    {
        return await users.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.Id == Id, cancellationToken);
    }
}
