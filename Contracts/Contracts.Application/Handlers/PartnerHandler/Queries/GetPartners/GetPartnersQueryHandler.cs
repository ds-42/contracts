using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Handlers.OrgHandler;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.BaseHandlers;
using Core.Auth.Application.Abstractions.Service;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.PartnerHandler.Queries.GetPartners;

public class GetPartnersHandler(
        IBaseReadRepository<Partner> partners,
        ICurrentUserService user,
        PartnerMemoryCache cache,
        IMapper mapper) : PaginatedQueryHandler<Partner, GetPartnersQuery, PartnerDto>(partners, mapper, cache)
{
    protected override Expression<Func<Partner, bool>>? Filter(GetPartnersQuery query)
    {
        return t => t.OrgId == user.OrgId;
    }

    protected override Expression<Func<Partner, object>> SortBy(GetPartnersQuery query)
    {
        return t => t.ViewName;
    }

    protected override PartnerDto MapRecord(Partner model)
    {
        var result = mapper.Map<PartnerDto>(model.PartnerOrg);
        result.ViewName = model.ViewName;
        return result;
    }

}
