using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;

namespace Contracts.Application.Extensions;

public static class ContractOrgExtension
{
    public static async Task<bool> UsedOrg(this IBaseReadRepository<Contract> contracts, int OrgId, CancellationToken cancellationToken)
    {
        return await contracts.AsAsyncRead()
            .AnyAsync(t => t.OrgId == OrgId || t.PartnerId == OrgId, cancellationToken);
    }
}
