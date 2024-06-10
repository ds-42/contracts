using Contracts.Application.Handlers.ContractDocHandler.Commands.CreateContractDoc;
using Contracts.Application.Handlers.ContractHandler.Commands.CreateContract;
using Contracts.Application.Handlers.ContractHandler.Queries.GetContracts;
using Contracts.Application.Handlers.DocumentHandler.Commands.CreateDocument;
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
