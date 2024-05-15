using Contracts.Application.Handlers.OrgHandler.Commands.CreateOrg;
using Contracts.Application.Handlers.OrgHandler.Queries.GetOrgs;
using Core.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Contracts.Api.Controllers;

public class OrgsController(IMediator mediator) 
    : AuthController(mediator)
{

    [HttpGet]
    public async Task<IActionResult> GetContracts(
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

}

