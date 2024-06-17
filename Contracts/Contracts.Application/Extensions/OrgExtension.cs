using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Exceptions;

namespace Contracts.Application.Extensions;

public static class OrgExtension
{
    public static async Task<Org?> FindItem(this IBaseReadRepository<Org> orgs, int Id, CancellationToken cancellationToken)
    {
        return await orgs.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.Id == Id, cancellationToken);
    }

    public static async Task<Org> GetItem(this IBaseReadRepository<Org> orgs, int Id, CancellationToken cancellationToken)
    {
        var rec = await FindItem(orgs, Id, cancellationToken);

        if (rec == null)
            throw new NotFoundException($"Org with id={Id} not found");

        return rec;
    }

    public static async Task TestExists(this IBaseReadRepository<Org> orgs, int Id, CancellationToken cancellationToken)
    {
        await GetItem(orgs, Id, cancellationToken);
    }
}

