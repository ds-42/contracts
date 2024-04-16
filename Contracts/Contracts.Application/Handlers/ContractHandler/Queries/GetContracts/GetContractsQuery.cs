using Contracts.Application.DTOs;
using Core.Application.DTOs;
using MediatR;

namespace Contracts.Application.Handlers.ContractHandler.Queries.GetContracts;

public class GetContractsQuery : ContractsFilter, IRequest<CountableList<GetContractDto>>
{
}
