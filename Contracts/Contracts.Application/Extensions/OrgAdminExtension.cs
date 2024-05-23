using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Exceptions;

namespace Contracts.Application.Extensions;

public static class OrgAdminExtension
{
    public static async Task<OrgAdmin?> FindOrg(this IBaseReadRepository<OrgAdmin> source, int orgId, int userId, CancellationToken cancellationToken)
    {
        return await source.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.OrgId == orgId && t.UserId == userId, cancellationToken);
    }

    public static async Task TestAccess(this IBaseReadRepository<OrgAdmin> source, int orgId, int userId, CancellationToken cancellationToken)
    {
        var rec = await source.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.OrgId == orgId && t.UserId == userId, cancellationToken);

        if (rec == null)
            throw new AccessDeniedException();
    }

}
