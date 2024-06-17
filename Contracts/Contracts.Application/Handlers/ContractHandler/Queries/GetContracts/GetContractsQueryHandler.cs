using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Application.Handlers.DocumentHandler;
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
        IMapper mapper) : PaginatedQueryHandler<Contract, GetContractsQuery, ContractExDto>(contracts, mapper, cache)
{

    protected override async Task TestDataAccessAsync(GetContractsQuery query, CancellationToken cancellationToken)
    {
        await employees.TestAccess(query.OrgId, user.Id, cancellationToken);
    }

    protected override Expression<Func<Contract, object>> SortBy(GetContractsQuery query)
    {
        return t => t.StartDate;
    }

    protected override ContractExDto MapRecord(Contract model)
    {
        var result = base.MapRecord(model);
        result.FormatName = model.Format.Name;
        result.CurrencyName = model.Currency.Name;
        result.CurrencyShortName = model.Currency.ShortName;
        return result;
    }

}
