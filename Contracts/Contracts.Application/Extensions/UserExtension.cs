using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Exceptions;
using Core.Users.Domain;

namespace Contracts.Application.Extensions;

public static class UserExtension
{
    public static async Task<User> GetItem(this IBaseReadRepository<User> users, int Id, CancellationToken cancellationToken)
    {
        var rec = await users.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.Id == Id, cancellationToken);

        if (rec == null)
            throw new AccessDeniedException();

        return rec;
    }
}
