using Contracts.Application.Handlers.CurrencyHandler.Commands.CreateCurrency;
using Contracts.Application.Handlers.CurrencyHandler.Commands.UpdateCurrency;
using Contracts.Application.Handlers.FormatHandler.Commands.CreateFormat;

namespace Contracts.Application.Handlers.EmployeeHandler.Queries.GetEmployees;

public class CreateCurrencyCommandValidator : CurrencyValidator<CreateCurrencyCommand>
{
    public CreateCurrencyCommandValidator()
    {
        RuleForName(t => t.Name);
        RuleForShortName(t => t.ShortName);
        RuleForAbbrev(t => t.Abbrev);
    }
}
