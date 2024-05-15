﻿using Contracts.Application.Handlers.CurrencyHandler.Queries.GetCurrencies;

namespace Contracts.Application.Handlers.EmployeeHandler.Queries.GetEmployees;

public class GetCurrenciesQueryValidator : CurrencyValidator<GetCurrenciesQuery>
{
    public GetCurrenciesQueryValidator()
    {
        RuleForPagination(t => t);
    }
}
