using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Exceptions;

namespace Contracts.Application.Extensions;

public static class EmployeeExtension
{
    public static async Task<Employee?> FindItem(this IBaseReadRepository<Employee> source, int orgId, int userId, CancellationToken cancellationToken)
    {
        return await source.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.OrgId == orgId && t.UserId == userId, cancellationToken);
    }

    public static async Task<Employee> GetItem(this IBaseReadRepository<Employee> employees, int OrgId, int Id, CancellationToken cancellationToken)
    {
        var rec = await FindItem(employees, OrgId, Id, cancellationToken);

        if (rec == null)
            throw new NotFoundException($"Employee with id={Id} not found");

        return rec;
    }

    public static async Task TestAccess(this IBaseReadRepository<Employee> source, int orgId, int userId, CancellationToken cancellationToken)
    {
        var rec = await FindItem(source, orgId, userId, cancellationToken);

        if (rec == null)
            throw new AccessDeniedException();
    }
}
