using Contracts.Application.Handlers.EmployeeHandler;
using FluentValidation;

namespace Contracts.Application.Handlers.ContractHandler.Commands.UpdateContract;

public class UpdateContractCommandValidator : ContractValidator<UpdateContractCommand>
{
    public UpdateContractCommandValidator()
    {
        RuleForId(t => t.Id);
        RuleForId(t => t.FormatId);
        RuleForId(t => t.CurrencyId);
        RuleForNumber(t => t.Number);
        RuleForRegistryDate(t => t.RegistryDate);
        RuleForStartDate(t => t.StartDate);
        RuleForPlannedPrice(t => t.PlannedPrice);
        RuleForDescription(t => t.Description);
        RuleFor(t => t.Role).IsInEnum();
        RuleFor(t => t.State).IsInEnum();
    }
}
