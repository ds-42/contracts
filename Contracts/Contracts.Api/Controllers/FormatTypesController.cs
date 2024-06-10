using Contracts.Application.Handlers.FormatTypeHandler.Commands.CreateFormatType;
using Contracts.Application.Handlers.FormatTypeHandler.Commands.DeleteFormatType;
using Contracts.Application.Handlers.FormatTypeHandler.Commands.UpdateFormatType;
using Contracts.Application.Handlers.FormatTypeHandler.Queries.GetFormatTypes;
using Contracts.Application.Handlers.OwnershipHandler.Commands.CreateOwnership;
using Contracts.Application.Handlers.OwnershipHandler.Commands.UpdateOwnership;
using Contracts.Application.Handlers.OwnershipHandler.Queries.GetOwnership;
using Core.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contracts.Api.Controllers;

public class FormatTypesController : AuthController
{
    public FormatTypesController(IMediator mediator) : base(mediator)
    {
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetFormatTypes(
        [FromQuery] GetFormatTypesQuery query, CancellationToken cancellationToken = default)
    {
        var data = await ExecQueryAsync(query, cancellationToken);

        SetTotalCountHeader(data.Count);
        return Ok(data.Items);
    }

    [HttpPost]
    public async Task<IActionResult> AppendFormatType(
        CreateFormatTypeCommand command,
        CancellationToken cancellationToken = default)
    {
        var formatType = await ExecQueryAsync(command, cancellationToken);

        return Created($"FormatTypes/{formatType.Id}", formatType);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFormatType(
        int id,
        UpdateFormatTypeCommand command,
        CancellationToken cancellationToken = default)
    {
        command.Id = id;
        var format = await ExecQueryAsync(command, cancellationToken);

        return Ok(format);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFormatType(
        int id,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteFormatTypeCommand() { Id = id };
        await ExecQueryAsync(command, cancellationToken);

        return Ok();
    }
}

