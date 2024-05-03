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

namespace Contracts.Application.Handlers.EmployeeHandler;

public class EmployeesGetQuery : BasePagination, IRequest<CountableList<EmployeeView>>
{
    public int OrgId { get; set; }
}

public class EmployeesGetHandler(
    IBaseReadRepository<Employee> employes,
    ICurrentUserService user,
    EmployeeMemoryCache cache,
    IMapper mapper) : PaginatedQueryHandler<Employee, EmployeesGetQuery, EmployeeView>(employes, mapper, cache)
{
    protected override async Task TestDataAccessAsync(EmployeesGetQuery query, CancellationToken cancellationToken)
    {
        // Проверка является ли пользователем организации
        await _source.GetItem(query.OrgId, user.Id, cancellationToken);
    }

    protected override Expression<Func<Employee, bool>>? Filter(EmployeesGetQuery query)
    {
        return t => t.OrgId == query.OrgId;
    }
}

public class EmployeesGetValidator : EmployeeValidator<EmployeesGetQuery>
{
    public EmployeesGetValidator()
    {
        RuleForId(e => e.OrgId);
    }
}