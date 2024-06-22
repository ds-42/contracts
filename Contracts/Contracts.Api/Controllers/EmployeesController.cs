using Contracts.Application.Handlers.EmployeeHandler.Commands.CreateEmployee;
using Contracts.Application.Handlers.EmployeeHandler.Commands.DeleteEmployee;
using Contracts.Application.Handlers.EmployeeHandler.Commands.UpdateEmployee;
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
    public async Task<IActionResult> CreateEmployee(
        CreateEmployeeCommand command,
        CancellationToken cancellationToken = default)
    {
        var employee = await ExecQueryAsync(command, cancellationToken);

        return Created($"Employees/{employee.UserId}", employee);
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateEmployee(
        int userId,
        UpdateEmployeeCommand command,
        CancellationToken cancellationToken = default)
    {
        command.UserId = userId;
        var employee = await ExecQueryAsync(command, cancellationToken);

        return Ok(employee);
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteEmployee(
        int userId,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteEmployeeCommand() { UserId = userId };
        await ExecQueryAsync(command, cancellationToken);

        return Ok();
    }

}

