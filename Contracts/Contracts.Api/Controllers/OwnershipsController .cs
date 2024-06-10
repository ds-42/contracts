using Contracts.Application.Handlers.FormatTypeHandler.Commands.CreateFormatType;
using Contracts.Application.Handlers.FormatTypeHandler.Commands.DeleteFormatType;
using Contracts.Application.Handlers.FormatTypeHandler.Commands.UpdateFormatType;
using Contracts.Application.Handlers.FormatTypeHandler.Queries.GetFormatTypes;
using Contracts.Application.Handlers.OwnershipHandler.Commands.CreateOwnership;
using Contracts.Application.Handlers.OwnershipHandler.Commands.DeleteOwnership;
using Contracts.Application.Handlers.OwnershipHandler.Commands.UpdateOwnership;
using Contracts.Application.Handlers.OwnershipHandler.Queries.GetOwnership;
using Contracts.Domain;
using Core.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contracts.Api.Controllers;

public class OwnershipsController : AuthController
{
    public OwnershipsController(IMediator mediator) : base(mediator)
    {
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetOwnerships(
        [FromQuery] GetOwnershipsQuery query, CancellationToken cancellationToken = default)
    {
        var data = await ExecQueryAsync(query, cancellationToken);

        SetTotalCountHeader(data.Count);
        return Ok(data.Items);
    }

    [HttpPost]
    public async Task<IActionResult> AppendOwnership(
        CreateOwnershipCommand command,
        CancellationToken cancellationToken = default)
    {
        var ownership = await ExecQueryAsync(command, cancellationToken);

        return Created($"Ownerships/{ownership.Id}", ownership);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOwnership(
        int id,
        UpdateOwnershipCommand command,
        CancellationToken cancellationToken = default)
    {
        command.Id = id;
        var ownership = await ExecQueryAsync(command, cancellationToken);

        return Ok(ownership);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOwnership(
        int id,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteOwnershipCommand() { Id = id };
        await ExecQueryAsync(command, cancellationToken);

        return Ok();
    }
}

