using MediatR;

namespace Contracts.Application.Handlers.EmployeeHandler.Commands.DeleteEmployee;

public class DeleteEmployeeCommand : IRequest<bool>
{
    public int UserId { get; set; }
}


