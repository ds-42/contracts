using Contracts.Application.Handlers.EmployeeHandler;

namespace Contracts.Application.Handlers.ContractHandler.Commands.UpdateContract;

public class UpdateContractCommandValidator : ContractValidator<UpdateContractCommand>
{
    public UpdateContractCommandValidator()
    {
        RuleForId(t => t.Id);
        RuleForId(t => t.FormatId);
    }
}
