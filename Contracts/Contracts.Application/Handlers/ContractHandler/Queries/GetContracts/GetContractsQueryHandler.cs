using AutoMapper;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.DTOs;
using Core.Application.Handlers.Quaries;
using Core.Auth.Application.Abstractions.Service;
using MediatR;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.ContractHandler.Queries.GetContracts;

/*public class GetContractsQueryHandler : PaginatedQueryHandler<Contract, GetContractsQuery, GetContractDto>
{
    public GetContractsQueryHandler(
    IBaseReadRepository<Contract> directions,
    ICurrentUserService _currentUserService,
    ContractsMemoryCache cache,
    IMapper mapper) : base(directions, mapper, cache.Cache, 1)
    {
    }

/*    protected override Expression<Func<Contract, bool>> Filter(GetContractsQuery query)
    {
        return t => t.Orgs.;
    }* /

    protected virtual Expression<Func<Contract, object>> SortBy(GetContractsQuery query)
    {
        return t => t.StartDate;
    }

}*/
