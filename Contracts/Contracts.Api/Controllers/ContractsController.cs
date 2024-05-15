using Contracts.Application.Handlers.ContractHandler.Commands.ContractAdd;
using Contracts.Application.Handlers.ContractHandler.Queries.GetContracts;
using Core.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Contracts.Api.Controllers;

public class ContractsController : AuthController
{
    public ContractsController(IMediator mediator) : base(mediator) 
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetContracts(
        [FromQuery] GetContractsQuery getListQuery, CancellationToken cancellationToken = default)
    {
        var data = await ExecQueryAsync(getListQuery, cancellationToken);

        SetTotalCountHeader(data.Count);
        return Ok(data.Items);
    }

    [HttpPost]
    public async Task<IActionResult> AppendContract(
        CreateContractCommand command,
        CancellationToken cancellationToken = default)
    {
        var contract = await ExecQueryAsync(command, cancellationToken);

        return Created($"Contracts/{contract.Id}", contract);
    }


}
