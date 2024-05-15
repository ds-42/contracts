using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.BaseHandlers;
using Core.Auth.Application.Abstractions.Service;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.ContractHandler.Queries.GetContracts;

public class GetContractsQueryHandler(
        IBaseReadRepository<Contract> contracts,
        IBaseReadRepository<Employee> employees,
        ICurrentUserService user,
        ContractMemoryCache cache,
        IMapper mapper) : PaginatedQueryHandler<Contract, GetContractsQuery, ContractDto>(contracts, mapper, cache)
{

    protected override async Task TestDataAccessAsync(GetContractsQuery query, CancellationToken cancellationToken)
    {
        await employees.TestAccess(query.OrgId, user.Id, cancellationToken);
    }

    protected override Expression<Func<Contract, object>> SortBy(GetContractsQuery query)
    {
        return t => t.StartDate;
    }
}
