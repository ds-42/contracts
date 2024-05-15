using Contracts.Application.Handlers.EmployeeHandler.Commands.CreateEmployee;
using Contracts.Application.Handlers.EmployeeHandler.Queries.GetEmployees;
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
        [FromQuery] GetEmployeesQuery query, CancellationToken cancellationToken = default)
    {
        var data = await ExecQueryAsync(query, cancellationToken);

        SetTotalCountHeader(data.Count);
        return Ok(data.Items);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrg(
        CreateEmployeeCommand command, 
        CancellationToken cancellationToken = default)
    {
        var employee = await ExecQueryAsync(command, cancellationToken);

        return Created($"Employees/{employee.Id}", employee);
    }

}

