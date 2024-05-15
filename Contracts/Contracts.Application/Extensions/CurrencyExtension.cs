using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Exceptions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Contracts.Application.Extensions;

public static class CurrencyExtension
{
    public static async Task<Currency?> FindItem(this IBaseReadRepository<Currency> currencies, int Id, CancellationToken cancellationToken)
    {
        return await currencies.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.Id == Id, cancellationToken);
    }

    public static async Task<Currency> GetItem(this IBaseReadRepository<Currency> currencies, int Id, CancellationToken cancellationToken)
    {
        var rec = await FindItem(currencies, Id, cancellationToken);

        if (rec == null)
            throw new NotFoundException($"Currency with id={Id} not found");

        return rec;
    }

    public static async Task TestExists(this IBaseReadRepository<Currency> currencies, int Id, CancellationToken cancellationToken)
    {
        await GetItem(currencies, Id, cancellationToken);
    }

    public static async Task TestDuplicate(this IBaseReadRepository<Currency> currencies, int id, string abbrev, CancellationToken cancellationToken)
    {
        var currency = await currencies.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.Id != id && t.Abbrev == abbrev, cancellationToken);

        if (currency != null)
            throw new DuplicatedException<Currency>();
    }
}
