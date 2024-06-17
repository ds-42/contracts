using Contracts.Application.Handlers.ContractDocHandler.Commands.CreateContractDoc;
using Contracts.Application.Handlers.ContractDocHandler.Commands.DeleteContractDoc;
using Contracts.Application.Handlers.ContractDocHandler.Commands.UpdateContractDoc;
using Contracts.Application.Handlers.ContractDocHandler.Queries.GetContractsвDocs;
using Contracts.Application.Handlers.ContractHandler.Commands.CreateContract;
using Contracts.Application.Handlers.ContractHandler.Commands.DeleteContract;
using Contracts.Application.Handlers.ContractHandler.Commands.UpdateContract;
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

    #region Contracts

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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContract(
        int id,
        UpdateContractCommand command,
        CancellationToken cancellationToken = default)
    {
        command.Id = id;
        var contract = await ExecQueryAsync(command, cancellationToken);

        return Ok(contract);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContract(
        int id,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteContractCommand() { Id = id };
        await ExecQueryAsync(command, cancellationToken);

        return Ok();
    }

    #endregion

    #region Documents

    [HttpGet("Docs")]
    public async Task<IActionResult> GetContractDocs(
        [FromQuery] GetContractDocsQuery getListQuery, CancellationToken cancellationToken = default)
    {
        var data = await ExecQueryAsync(getListQuery, cancellationToken);

        SetTotalCountHeader(data.Count);
        return Ok(data.Items);
    }

    [HttpPost("Docs")]
    public async Task<IActionResult> AppendDocument(
        CreateContractDocCommand command,
        CancellationToken cancellationToken = default)
    {
        var doc = await ExecQueryAsync(command, cancellationToken);

        return Created($"ContractDocs/{doc.Id}", doc);
    }

    [HttpPut("Docs")]
    public async Task<IActionResult> UpdateDocument(
        UpdateContractDocCommand command,
        CancellationToken cancellationToken = default)
    {
        var doc = await ExecQueryAsync(command, cancellationToken);

        return Ok(doc);
    }

    [HttpDelete("Docs/{id}")]
    public async Task<IActionResult> DeleteDocument(
        int id,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteContractDocCommand() { Id = id };
        await ExecQueryAsync(command, cancellationToken);

        return Ok();
    }

    #endregion
}
