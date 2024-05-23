using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Exceptions;

namespace Contracts.Application.Extensions;

public static class FormatExtension
{
    public static async Task<Format?> FindItem(this IBaseReadRepository<Format> formats, int Id, CancellationToken cancellationToken)
    {
        return await formats.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.Id == Id, cancellationToken);
    }

    public static async Task<Format> GetItem(this IBaseReadRepository<Format> formats, int Id, CancellationToken cancellationToken)
    {
        var rec = await FindItem(formats, Id, cancellationToken);

        if (rec == null)
            throw new NotFoundException($"Format with id={Id} not found");

        return rec;
    }

    public static async Task TestExists(this IBaseReadRepository<Format> formats, int Id, CancellationToken cancellationToken)
    {
        await GetItem(formats, Id, cancellationToken);
    }

    public static async Task<bool> UsedFormatType(this IBaseReadRepository<Format> formats, int FormatTypeId, CancellationToken cancellationToken)
    {
        return await formats.AsAsyncRead()
            .AnyAsync(t => t.FormatTypeId == FormatTypeId, cancellationToken);
    }
}
