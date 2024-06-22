using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Handlers.AddressHandler;
using Contracts.Application.Services;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.BaseHandlers;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.OrgAddressHandler.Queries.GetOrgAddresses;

public class GetOrgAddressesQueryHandler(
        IBaseReadRepository<Address> addresses,
        СontractorService contractor,
        AddressCache cache,
        IMapper mapper) : PaginatedQueryHandler<Address, GetOrgAddressesQuery, AddressDto>(addresses, mapper, cache)
{

    protected override async Task TestDataAccessAsync(GetOrgAddressesQuery query, CancellationToken cancellationToken)
    {
        await contractor.TestAccess(cancellationToken);
    }

    protected override async Task<Expression<Func<Address, bool>>?> FilterAsync(GetOrgAddressesQuery query, CancellationToken cancellationToken)
    {
        var org = await contractor.GetOrgAsync(cancellationToken);

        return t => t.Group == org.AddressGroup;
    }

    protected override Expression<Func<Address, object>> SortBy(GetOrgAddressesQuery query)
    {
        return t => t.Id;
    }
}
