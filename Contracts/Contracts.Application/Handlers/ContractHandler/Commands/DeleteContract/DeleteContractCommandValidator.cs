using Contracts.Application.Handlers.EmployeeHandler;

namespace Contracts.Application.Handlers.ContractHandler.Commands.DeleteContract;

public class DeleteContractCommandValidator : ContractValidator<DeleteContractCommand>
{
    public DeleteContractCommandValidator()
    {
        RuleForId(t => t.Id);
    }
}
