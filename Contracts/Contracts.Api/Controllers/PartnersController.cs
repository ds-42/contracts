using Contracts.Application.Handlers.PartnerHandler.Commands.CreatePartner;
using Contracts.Application.Handlers.PartnerHandler.Commands.DeletePartner;
using Contracts.Application.Handlers.PartnerHandler.Commands.UpdatePartner;
using Contracts.Application.Handlers.PartnerHandler.Queries.GetPartners;
using Core.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Contracts.Api.Controllers;

public class PartnersController(IMediator mediator)
    : AuthController(mediator)
{
    [HttpGet]
    public async Task<IActionResult> GetPartners(
        [FromQuery] GetPartnersQuery query, CancellationToken cancellationToken = default)
    {
        var data = await ExecQueryAsync(query, cancellationToken);

        SetTotalCountHeader(data.Count);
        return Ok(data.Items);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePartner(
        CreatePartnerCommand command, CancellationToken cancellationToken = default)
    {
        var org = await ExecQueryAsync(command, cancellationToken);

        return Created($"Orgs/{org.Id}", org);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePartner(
        int id,
        UpdatePartnerCommand command,
        CancellationToken cancellationToken = default)
    {
        command.Id = id;
        var org = await ExecQueryAsync(command, cancellationToken);

        return Ok(org);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePartner(
        int id,
        CancellationToken cancellationToken = default)
    {
        var command = new DeletePartnerCommand() { Id = id };
        await ExecQueryAsync(command, cancellationToken);

        return Ok();
    }
}

