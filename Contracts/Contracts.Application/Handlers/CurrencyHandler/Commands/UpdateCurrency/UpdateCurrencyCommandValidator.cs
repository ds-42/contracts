using Contracts.Application.Handlers.EmployeeHandler;
using Contracts.Application.Handlers.FormatHandler;

namespace Contracts.Application.Handlers.CurrencyHandler.Commands.UpdateCurrency;

public class UpdateCurrencyCommandValidator : CurrencyValidator<UpdateCurrencyCommand>
{
    public UpdateCurrencyCommandValidator()
    {
        RuleForId(t => t.Id);
        RuleForName(t => t.Name);
        RuleForShortName(t => t.ShortName);
        RuleForAbbrev(t => t.Abbrev);
    }
}
