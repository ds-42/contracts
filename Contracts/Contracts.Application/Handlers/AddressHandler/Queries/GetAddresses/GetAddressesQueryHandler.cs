using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.BaseHandlers;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.AddressHandler.Queries.GetAddresses;

public class GetAddressesQueryHandler(
    IBaseReadRepository<Address> addresses,
    AddressCache cache,
    IMapper mapper) : PaginatedQueryHandler<Address, GetAddressesQuery, AddressDto>(addresses, mapper, cache)
{
    protected override Expression<Func<Address, bool>>? Filter(GetAddressesQuery query)
    {
        return t => t.Group == query.Group;
    }

}