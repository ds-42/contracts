using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Exceptions;

namespace Contracts.Application.Extensions;

public static class FileExtension
{
    public static async Task<Domain.File?> FindItem(this IBaseReadRepository<Domain.File> files, int Id, CancellationToken cancellationToken)
    {
        return await files.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.Id == Id, cancellationToken);
    }

    public static async Task<Domain.File> GetItem(this IBaseReadRepository<Domain.File> files, int Id, CancellationToken cancellationToken)
    {
        var rec = await FindItem(files, Id, cancellationToken);

        if (rec == null)
            throw new NotFoundException($"File with id={Id} not found");

        return rec;
    }

    public static async Task TestExists(this IBaseReadRepository<Domain.File> files, int Id, CancellationToken cancellationToken)
    {
        await GetItem(files, Id, cancellationToken);
    }
}
