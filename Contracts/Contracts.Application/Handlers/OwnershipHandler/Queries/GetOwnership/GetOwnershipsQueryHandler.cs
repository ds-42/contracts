using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.BaseHandlers;

namespace Contracts.Application.Handlers.OwnershipHandler.Queries.GetOwnership;

public class GetOwnershipsQueryHandler(
    IBaseReadRepository<Ownership> ownerships,
    OwnershipCache cache,
    IMapper mapper) : PaginatedQueryHandler<Ownership, GetOwnershipsQuery, OwnershipDto>(ownerships, mapper, cache)
{

}