using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.BaseHandlers;
using Core.Auth.Application.Abstractions.Service;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.EmployeeHandler.Queries.GetEmployees;

public class GetEmployeesQueryHandler(
    IBaseReadRepository<Employee> employes,
    ICurrentUserService user,
    EmployeeMemoryCache cache,
    IMapper mapper) : PaginatedQueryHandler<Employee, GetEmployeesQuery, EmployeeDto>(employes, mapper, cache)
{
    protected override async Task TestDataAccessAsync(GetEmployeesQuery query, CancellationToken cancellationToken)
    {
        await _source.TestAccess(query.OrgId, user.Id, cancellationToken);
    }

    protected override Expression<Func<Employee, bool>>? Filter(GetEmployeesQuery query)
    {
        return t => t.OrgId == query.OrgId;
    }
}