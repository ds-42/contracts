using Contracts.Application.Handlers.EmployeeHandler;

namespace Contracts.Application.Handlers.CurrencyHandler.Commands.DeleteCurrency;

public class DeleteCurrencyCommandValidator : CurrencyValidator<DeleteCurrencyCommand>
{
    public DeleteCurrencyCommandValidator()
    {
        RuleForId(t => t.Id);
    }
}
