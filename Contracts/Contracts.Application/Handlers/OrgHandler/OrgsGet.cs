using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Handlers.OrgHandler;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.BaseHandlers;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;
using MediatR;

namespace Contracts.Application.Handlers.EmployeeHandler;

public class OrgsGetQuery : BasePagination, IRequest<CountableList<OrgView>>
{
}


public class OrgsGetHandler : PaginatedQueryHandler<Org, OrgsGetQuery, OrgView>
{
    public OrgsGetHandler(
        IBaseReadRepository<Org> orgs,
        //        ICurrentUserService _user,
        OrgMemoryCache cache,
        IMapper mapper) : base(orgs, mapper, cache) { }
}

public class OrgsGetValidator : OrgValidator<OrgsGetQuery>
{
    public OrgsGetValidator()
    {
    }
}