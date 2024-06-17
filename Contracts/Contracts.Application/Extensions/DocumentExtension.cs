using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Exceptions;

namespace Contracts.Application.Extensions;

public static class DocumentExtension
{
    public static async Task<Document?> FindItem(this IBaseReadRepository<Document> documents, int group, int Id, CancellationToken cancellationToken)
    {
        return await documents.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.Id == Id && (group == 0 || t.Group == group), cancellationToken);
    }

    public static async Task<Document> GetItem(this IBaseReadRepository<Document> documents, int group, int Id, CancellationToken cancellationToken)
    {
        var rec = await FindItem(documents, group, Id, cancellationToken);

        if (rec == null)
            throw new NotFoundException($"Document with id={Id} not found");

        return rec;
    }

    public static async Task TestExists(this IBaseReadRepository<Document> documents, int group, int Id, CancellationToken cancellationToken)
    {
        await GetItem(documents, group, Id, cancellationToken);
    }
}
