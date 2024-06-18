using Contracts.Application.Handlers.EmployeeHandler;
using Contracts.Domain.Enums;
using FluentValidation;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.ContractHandler.Commands.CreateContract;

public class CreateContractCommandValidator : ContractValidator<CreateContractCommand>
{
    public CreateContractCommandValidator()
    {
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
