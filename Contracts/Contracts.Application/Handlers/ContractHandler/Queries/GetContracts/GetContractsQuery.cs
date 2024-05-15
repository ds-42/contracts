using Core.Application.BaseRealizations;
using Core.Application.DTOs;
using MediatR;

namespace Contracts.Application.Handlers.ContractHandler.Queries.GetContracts;

public class GetContractsQuery : BasePagination, IRequest<CountableList<ContractDto>>
{
    public int OrgId { get; set; }
}


