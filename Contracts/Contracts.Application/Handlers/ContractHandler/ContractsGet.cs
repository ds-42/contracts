using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.BaseHandlers;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;
using Core.Auth.Application.Abstractions.Service;
using MediatR;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.ContractHandler;

public class ContractsGetQuery : BasePagination, IRequest<CountableList<ContractView>>
{
    public int OrgId { get; set; }
}

public class ContractsGetHandler(
        IBaseReadRepository<Contract> contracts,
        IBaseReadRepository<Employee> employees,
        ICurrentUserService user,
        ContractMemoryCache cache,
        IMapper mapper) : PaginatedQueryHandler<Contract, ContractsGetQuery, ContractView>(contracts, mapper, cache)
{

    protected override async Task TestDataAccessAsync(ContractsGetQuery query, CancellationToken cancellationToken)
    {
        // Проверка является ли пользователем организации
        await employees.GetItem(query.OrgId, user.Id, cancellationToken);
    }

    protected override Expression<Func<Contract, object>> SortBy(ContractsGetQuery query)
    {
        return t => t.StartDate;
    }
}


