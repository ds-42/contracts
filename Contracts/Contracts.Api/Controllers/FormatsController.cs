using Contracts.Application.Handlers.FormatHandler.Commands.CreateFormat;
using Contracts.Application.Handlers.FormatHandler.Commands.DeleteFormat;
using Contracts.Application.Handlers.FormatHandler.Commands.UpdateFormat;
using Contracts.Application.Handlers.FormatHandler.Queries.GetFormats;
using Core.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contracts.Api.Controllers;

public class FormatsController : AuthController
{
    public FormatsController(IMediator mediator) : base(mediator)
    {
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetFormats(
        [FromQuery] GetFormatsQuery query, CancellationToken cancellationToken = default)
    {
        var data = await ExecQueryAsync(query, cancellationToken);

        SetTotalCountHeader(data.Count);
        return Ok(data.Items);
    }

    [HttpPost]
    public async Task<IActionResult> AppendFormat(
        CreateFormatCommand command,
        CancellationToken cancellationToken = default)
    {
        var format = await ExecQueryAsync(command, cancellationToken);

        return Created($"Formats/{format.Id}", format);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFormat(
        int id,
        UpdateFormatCommand command,
        CancellationToken cancellationToken = default)
    {
        command.Id = id;
        var format = await ExecQueryAsync(command, cancellationToken);

        return Ok(format);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFormat(
        int id,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteFormatCommand() { Id = id };
        await ExecQueryAsync(command, cancellationToken);

        return Ok();
    }
}

