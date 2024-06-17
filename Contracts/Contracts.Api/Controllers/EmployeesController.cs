using Contracts.Application.Handlers.EmployeeHandler.Commands.CreateEmployee;
using Contracts.Application.Handlers.EmployeeHandler.Commands.DeleteEmployee;
using Contracts.Application.Handlers.EmployeeHandler.Commands.UpdateEmployee;
using Contracts.Application.Handlers.EmployeeHandler.Queries.GetEmployees;
using Contracts.Application.Handlers.FormatHandler.Commands.DeleteFormat;
using Contracts.Application.Handlers.FormatHandler.Commands.UpdateFormat;
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

        return Created($"Employees/{employee.Id}", employee);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(
        int id,
        UpdateEmployeeCommand command,
        CancellationToken cancellationToken = default)
    {
        command.Id = id;
        var employee = await ExecQueryAsync(command, cancellationToken);

        return Ok(employee);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(
        int id,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteEmployeeCommand() { Id = id };
        await ExecQueryAsync(command, cancellationToken);

        return Ok();
    }

}

