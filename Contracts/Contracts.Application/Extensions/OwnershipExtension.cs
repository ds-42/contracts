using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Exceptions;

namespace Contracts.Application.Extensions;

public static class OwnershipExtension
{
    public static async Task<Ownership?> FindItem(this IBaseReadRepository<Ownership> ownerships, int Id, CancellationToken cancellationToken)
    {
        return await ownerships.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.Id == Id, cancellationToken);
    }

    public static async Task<Ownership> GetItem(this IBaseReadRepository<Ownership> ownerships, int Id, CancellationToken cancellationToken)
    {
        var rec = await FindItem(ownerships, Id, cancellationToken);

        if (rec == null)
            throw new NotFoundException($"Ownership with id={Id} not found");

        return rec;
    }

    public static async Task TestExists(this IBaseReadRepository<Ownership> ownerships, int Id, CancellationToken cancellationToken)
    {
        await GetItem(ownerships, Id, cancellationToken);
    }
}
