using Contracts.Application.Handlers.AddressHandler.Commands.UpdateAddress;
using Contracts.Application.Handlers.OrgAddressHandler.Commands.CreateOrgAddress;
using Contracts.Application.Handlers.OrgAddressHandler.Commands.DeleteOrgAddress;
using Contracts.Application.Handlers.OrgAddressHandler.Queries.GetOrgAddresses;
using Contracts.Application.Handlers.OrgHandler.Commands.CreateOrg;
using Contracts.Application.Handlers.OrgHandler.Commands.DeleteOrg;
using Contracts.Application.Handlers.OrgHandler.Commands.UpdateOrg;
using Contracts.Application.Handlers.OrgHandler.Queries.GetOrgs;
using Core.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Contracts.Api.Controllers;

public class OrgsController(IMediator mediator)
    : AuthController(mediator)
{
    #region Orgs

    [HttpGet]
    public async Task<IActionResult> GetOrgs(
        [FromQuery] GetOrgsQuery query, CancellationToken cancellationToken = default)
    {
        var data = await ExecQueryAsync(query, cancellationToken);

        SetTotalCountHeader(data.Count);
        return Ok(data.Items);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrg(
        CreateOrgCommand command, CancellationToken cancellationToken = default)
    {
        var org = await ExecQueryAsync(command, cancellationToken);

        return Created($"Orgs/{org.Id}", org);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrg(
        int id,
        UpdateOrgCommand command,
        CancellationToken cancellationToken = default)
    {
        command.Id = id;
        var org = await ExecQueryAsync(command, cancellationToken);

        return Ok(org);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrg(
        int id,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteOrgCommand() { Id = id };
        await ExecQueryAsync(command, cancellationToken);

        return Ok();
    }

    #endregion

    #region Addresses

    [HttpGet("Addresses")]
    public async Task<IActionResult> GetContractAddresses(
        [FromQuery] GetOrgAddressesQuery query, CancellationToken cancellationToken = default)
    {
        var data = await ExecQueryAsync(query, cancellationToken);

        SetTotalCountHeader(data.Count);
        return Ok(data.Items);
    }

    [HttpPost("Addresses")]
    public async Task<IActionResult> CreateContractAddress(
        CreateOrgAddressCommand command, CancellationToken cancellationToken = default)
    {
        var addr = await ExecQueryAsync(command, cancellationToken);

        return Created($"Orgs/Addresses/{addr.Id}", addr);
    }

    [HttpPut("Addresses/{id}")]
    public async Task<IActionResult> UpdateContractAddresses(
        int id,
        UpdateOrgAddressCommand command,
        CancellationToken cancellationToken = default)
    {
        command.Id = id;
        var org = await ExecQueryAsync(command, cancellationToken);

        return Ok(org);
    }

    [HttpDelete("Addresses/{id}")]
    public async Task<IActionResult> DeleteContractAddress(
        int id,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteOrgAddressCommand() { Id = id };
        await ExecQueryAsync(command, cancellationToken);

        return Ok();
    }

    #endregion
}

