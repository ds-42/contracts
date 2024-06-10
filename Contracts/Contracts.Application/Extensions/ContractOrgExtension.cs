using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Contracts.Application.Extensions;

/*public static class ContractOrgExtension
{
    public static async Task<Contract?> FindContract(this IBaseReadRepository<ContractOrg> orgs, int OrgId, int ContractId, CancellationToken cancellationToken)
    {
        var rec = await orgs.AsQueryable()
            .Include
            .SingleOrDefaultAsync(t => t.OrgId == OrgId && t.ContractId == ContractId , cancellationToken);

        return rec?.Contract;
    }

    public static async Task<Contract> GetContract(this IBaseReadRepository<ContractOrg> orgs, int OrgId, int ContractId, CancellationToken cancellationToken)
    {
        var rec = await FindContract(orgs, OrgId, ContractId, cancellationToken);

        if (rec == null)
            throw new NotFoundException($"Contract with id={ContractId} not found");

        return rec;
    }
}*/
