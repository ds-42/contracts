using Core.Application.BaseRealizations;
using Core.Application.DTOs;
using MediatR;

namespace Contracts.Application.Handlers.ContractHandler.Queries.GetContracts;

public class GetContractsQuery : BasePagination, IRequest<CountableList<ContractExDto>>
{
    public int OrgId { get; set; }
}


