namespace Contracts.Application.Handlers.EmployeeHandler.Commands.DeleteEmployee;

public class DeleteEmployeeCommandValidator : EmployeeValidator<DeleteEmployeeCommand>
{
    public DeleteEmployeeCommandValidator()
    {
        RuleForId(t => t.Id);
    }
}
