using Contracts.Application.Handlers.EmployeeHandler;
using Core.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Contracts.Api.Controllers;

public class EmployeesController : AuthController
{
    public EmployeesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees(
        [FromQuery] EmployeesGetQuery query, CancellationToken cancellationToken = default)
    {
        var data = await ExecQueryAsync(query, cancellationToken);

        SetTotalCountHeader(data.Count);
        return Ok(data.Items);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrg(
        EmployeeAddCommand command, 
        CancellationToken cancellationToken = default)
    {
        var amployee = await ExecQueryAsync(command, cancellationToken);

        return Created($"employees/{amployee.Id}", amployee);
    }

}

