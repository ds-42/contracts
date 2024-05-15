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

    public static async Task TestExists(this IBaseReadRepository<User> users, int Id, CancellationToken cancellationToken)
    {
        var rec = await FindItem(users, Id, cancellationToken);

        if (rec == null)
            throw new NotFoundException($"User with id={Id} not found");
    }
}
