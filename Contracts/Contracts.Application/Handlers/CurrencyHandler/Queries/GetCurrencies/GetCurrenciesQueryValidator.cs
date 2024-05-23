using Contracts.Application.Handlers.CurrencyHandler.Queries.GetCurrencies;
using Contracts.Application.Handlers.FormatHandler.Queries.GetFormats;

namespace Contracts.Application.Handlers.EmployeeHandler.Queries.GetEmployees;

public class GetCurrenciesQueryValidator : CurrencyValidator<GetCurrenciesQuery>
{
    public GetCurrenciesQueryValidator()
    {
        RuleForPagination(t => t);
    }
}
