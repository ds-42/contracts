using Contracts.Application.Handlers.ContractDocHandler.Commands.CreateContractDoc;
using Contracts.Application.Handlers.ContractDocHandler.Commands.DeleteContractDoc;
using Contracts.Application.Handlers.ContractDocHandler.Commands.DownloadContractDoc;
using Contracts.Application.Handlers.ContractDocHandler.Commands.UpdateContractDoc;
using Contracts.Application.Handlers.ContractDocHandler.Queries.GetContractsвDocs;
using Contracts.Application.Handlers.ContractHandler.Commands.CreateContract;
using Contracts.Application.Handlers.ContractHandler.Commands.DeleteContract;
using Contracts.Application.Handlers.ContractHandler.Commands.UpdateContract;
using Contracts.Application.Handlers.ContractHandler.Queries.GetContracts;
using Contracts.Application.Services;
using Core.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

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
    public async Task<IActionResult> DeleteDocument(int id, CancellationToken cancellationToken = default)
    {
        var command = new DeleteContractDocCommand() { Id = id };
        await ExecQueryAsync(command, cancellationToken);

        return Ok();
    }

    [HttpGet("Docs/Download/{id}")]
    public async Task<IActionResult> DownloadFile(int id, CancellationToken cancellationToken = default)
    {
        var command = new DownloadContractDocCommand() { Id = id };

        DocumentInfo docInfo = await ExecQueryAsync(command, cancellationToken);

        if (!System.IO.File.Exists(docInfo.FilePath))
        {
            return NotFound();
        }

        var fileStream = new FileStream(docInfo.FilePath, FileMode.Open);
        return File(fileStream, "application/octet-stream", docInfo.FileName);
    }

    #endregion
}
