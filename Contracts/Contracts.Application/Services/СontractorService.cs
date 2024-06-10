using Contracts.Application.Extensions;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Application.Exceptions;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Services;

public class СontractorService(
    IBaseWriteRepository<Contract> contracts,
    IBaseReadRepository<Employee> employes,
    IBaseReadRepository<ContractOrg> orgs,
    IMediator mediator,
    ICurrentUserService user)
{
    public async Task<T> ExecCommandAsync<T>(IRequest<T> command, CancellationToken cancellationToken = default)
    {
        return await mediator.Send(command, cancellationToken);
    }

    public async Task<T> ExecQueryAsync<T>(IRequest<T> query, CancellationToken cancellationToken = default)
    {
        return await mediator.Send(query, cancellationToken);
    }

    public async Task TestAccess(int orgId, CancellationToken cancellationToken)
    {
        await employes.TestAccess(orgId, user.Id, cancellationToken);
    }

    public async Task TestContractAccess(int contractId, CancellationToken cancellationToken)
    {
        // чтение владельца договора
        var codes = await GetContractOrgs(contractId, cancellationToken);

        // проверка явлется ли пользователь сотрудником организации
        var recs = await employes.AsAsyncRead()
            .ToArrayAsync(t => t.UserId == user.Id, cancellationToken);

        if (!recs.Any(t => codes.Contains(t.OrgId)))
            throw new AccessDeniedException();

        //        var test = employes.AsAsyncRead()
        //            .Any(t => codes.Contains(t.OrgId));
    }

    public async Task<int[]> GetContractOrgs(int contractId, CancellationToken cancellationToken)
    {
        var recs = await orgs.AsAsyncRead()
            .ToArrayAsync(t => t.ContractId == contractId, cancellationToken);

        return recs.Select(t => t.OrgId).ToArray() ?? [];
    }

    public async Task<Contract> GetContractAsync(int contractId, CancellationToken cancellationToken)
    {
        var contract = await contracts.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.Id == contractId, cancellationToken);

        if (contract == null)
            throw new AccessDeniedException();

        return contract;
    }

    public async Task SaveContractAsync(Contract contract, CancellationToken cancellationToken) =>
        await contracts.UpdateAsync(contract, cancellationToken);


    public async Task<int> GetContractDocumentGroupAsync(int contractId, CancellationToken cancellationToken = default)
    {
        return (await contracts.AsAsyncRead()
            .SingleAsync(t => t.Id == contractId, cancellationToken))
            .DocumentsGroup;
    }

}
