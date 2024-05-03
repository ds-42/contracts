using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Exceptions;

namespace Contracts.Application.Extensions;

public static class EmployeeExtension
{
    public static async Task<Employee> GetItem(this IBaseReadRepository<Employee> source, int orgId, int userId, CancellationToken cancellationToken)
    {
        var rec = await source.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.OrgId == orgId && t.UserId == userId, cancellationToken);

        if (rec == null)
            throw new AccessDeniedException();

        return rec;
    }
}
