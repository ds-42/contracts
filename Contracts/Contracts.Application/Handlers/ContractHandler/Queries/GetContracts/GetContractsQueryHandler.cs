using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.DTOs;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.BaseHandlers;
using Core.Auth.Application.Abstractions.Service;
using MediatR;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.ContractHandler.Queries.GetContracts;

public class GetContractsQueryHandler : PaginatedQueryHandler<Contract, GetContractsQuery, GetContractDto>
{
    public GetContractsQueryHandler(
        IBaseReadRepository<Contract> contracts,
//        ICurrentUserService _currentUserService,
        ContractsMemoryCache cache,
        IMapper mapper) : base(contracts, mapper, cache)
    {
    }

/*    protected override Expression<Func<Contract, bool>> Filter(GetContractsQuery query)
    {
        return t => t.Orgs.;
    }*/

    protected override Expression<Func<Contract, object>> SortBy(GetContractsQuery query)
    {
        return t => t.StartDate;
    }

}
