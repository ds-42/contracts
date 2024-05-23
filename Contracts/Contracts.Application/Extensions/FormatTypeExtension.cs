using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Exceptions;

namespace Contracts.Application.Extensions;

public static class FormatTypeExtension
{
    public static async Task<FormatType?> FindItem(this IBaseReadRepository<FormatType> formatTypes, int Id, CancellationToken cancellationToken)
    {
        return await formatTypes.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.Id == Id, cancellationToken);
    }

    public static async Task<FormatType> GetItem(this IBaseReadRepository<FormatType> formatTypes, int Id, CancellationToken cancellationToken)
    {
        var rec = await FindItem(formatTypes, Id, cancellationToken);

        if (rec == null)
            throw new NotFoundException($"Format type with id={Id} not found");

        return rec;
    }

    public static async Task TestExists(this IBaseReadRepository<FormatType> formatTypes, int Id, CancellationToken cancellationToken)
    {
        await GetItem(formatTypes, Id, cancellationToken);
    }
}
