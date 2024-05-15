using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.BaseHandlers;

namespace Contracts.Application.Handlers.OrgHandler.Queries.GetOrgs;

public class OrgsGetHandler : PaginatedQueryHandler<Org, GetOrgsQuery, OrgDto>
{
    public OrgsGetHandler(
        IBaseReadRepository<Org> orgs,
        //        ICurrentUserService _user,
        OrgMemoryCache cache,
        IMapper mapper) : base(orgs, mapper, cache) { }
}
