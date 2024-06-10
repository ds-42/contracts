using Contracts.Application.Handlers.ContractDocHandler.Commands.CreateContractDoc;
using Contracts.Application.Handlers.ContractDocHandler.Commands.DeleteContractDoc;
using Contracts.Application.Handlers.ContractDocHandler.Commands.UpdateContractDoc;
using Contracts.Application.Handlers.ContractDocHandler.Queries.GetContractsвDocs;
using Core.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Contracts.Api.Controllers;

public class ContractDocsController : AuthController
{
    public ContractDocsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetContractDocs(
        [FromQuery] GetContractDocsQuery getListQuery, CancellationToken cancellationToken = default)
    {
        var data = await ExecQueryAsync(getListQuery, cancellationToken);

        SetTotalCountHeader(data.Count);
        return Ok(data.Items);
    }

    [HttpPost]
    public async Task<IActionResult> AppendDocument(
        CreateContractDocCommand command,
        CancellationToken cancellationToken = default)
    {
        var doc = await ExecQueryAsync(command, cancellationToken);

        return Created($"ContractDocs/{doc.Id}", doc);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDocument(
        UpdateContractDocCommand command,
        CancellationToken cancellationToken = default)
    {
        var doc = await ExecQueryAsync(command, cancellationToken);

        return Ok(doc);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDocument(
        int id,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteContractDocCommand() { Id = id };
        await ExecQueryAsync(command, cancellationToken);

        return Ok();
    }
}
