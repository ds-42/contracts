using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.BaseHandlers;
using Core.Auth.Application.Abstractions.Service;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.OrgHandler.Queries.GetOrgs;

public class OrgsGetHandler(
        IBaseReadRepository<Org> orgs,
        IBaseReadRepository<Employee> employees,
        ICurrentUserService user,
        OrgCache cache,
        IMapper mapper) : PaginatedQueryHandler<Org, GetOrgsQuery, OrgExDto>(orgs, mapper, cache)
{
    protected override async Task<Expression<Func<Org, bool>>?> FilterAsync(GetOrgsQuery query, CancellationToken cancellationToken)
    {
        HashSet<int>? ids = null;

        if (query.Me)
        {
            var orgs = (await employees.AsAsyncRead()
                .ToArrayAsync(t => t.UserId == user.Id, cancellationToken))
                .Select(t => t.OrgId).ToArray();

            ids = new HashSet<int>(orgs);
        }

        return t => ids == null || ids.Contains(t.Id);
    }

    protected override Expression<Func<Org, object>> SortBy(GetOrgsQuery query)
    {
        return t => t.ViewName;
    }

    protected override OrgExDto MapRecord(Org model)
    {
        var result = base.MapRecord(model);
        if (model.OwnershipId > 0)
        {
            result.Ownership = model.Ownership?.Name ?? "";
            result.FullName = $"{result.Ownership} \"{model.Name}\"";
        }
        else
        {
            result.Ownership = "";
            result.FullName = model.Name;
        }
        return result;
    }

}
