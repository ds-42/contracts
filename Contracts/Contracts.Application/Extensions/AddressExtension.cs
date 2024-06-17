using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Exceptions;

namespace Contracts.Application.Extensions;

public static class AddressExtension
{
    public static async Task<Address?> FindItem(this IBaseReadRepository<Address> addresses, int group, int Id, CancellationToken cancellationToken)
    {
        return await addresses.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.Id == Id && (group == 0 || t.Group == group), cancellationToken);
    }

    public static async Task<Address> GetItem(this IBaseReadRepository<Address> addresses, int group, int Id, CancellationToken cancellationToken)
    {
        var rec = await FindItem(addresses, group, Id, cancellationToken);

        if (rec == null)
            throw new NotFoundException($"Address with id={Id} not found");

        return rec;
    }

    public static async Task TestExists(this IBaseReadRepository<Address> addresses, int group, int Id, CancellationToken cancellationToken)
    {
        await GetItem(addresses, group, Id, cancellationToken);
    }
}
