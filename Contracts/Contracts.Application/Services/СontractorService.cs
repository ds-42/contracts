using Contracts.Application.Extensions;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Application.Exceptions;
using Core.Auth.Application.Abstractions.Service;

namespace Contracts.Application.Services;

public class СontractorService(
    IBaseWriteRepository<Contract> contracts,
    IBaseReadRepository<Employee> employes,
    IBaseWriteRepository<Org> orgs,
    ICurrentUserService user)
{

    public int OrgId => user.OrgId;
    public int UserId => user.Id;

    public async Task TestAccess(CancellationToken cancellationToken)
    {
        await employes.TestAccess(user.OrgId, user.Id, cancellationToken);
    }

    #region Orgs

    public async Task<Org> GetOrgAsync(CancellationToken cancellationToken)
    {
        var org = await orgs.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.Id == user.OrgId, cancellationToken);

        if (org == null)
            throw new AccessDeniedException();

        return org;
    }

    public async Task SaveOrgAsync(Org org, CancellationToken cancellationToken) =>
        await orgs.UpdateAsync(org, cancellationToken);

    #endregion

    #region Contracts

    public async Task<Contract> GetContractAsync(int contractId, CancellationToken cancellationToken)
    {
        var contract = await contracts.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.Id == contractId && t.OrgId == user.OrgId, cancellationToken);

        if (contract == null)
            throw new AccessDeniedException();

        return contract;
    }

    public async Task SaveContractAsync(Contract contract, CancellationToken cancellationToken) =>
        await contracts.UpdateAsync(contract, cancellationToken);

    public async Task RemoveContractAsync(Contract contract, CancellationToken cancellationToken) =>
        await contracts.RemoveAsync(contract, cancellationToken);

    #endregion
}
