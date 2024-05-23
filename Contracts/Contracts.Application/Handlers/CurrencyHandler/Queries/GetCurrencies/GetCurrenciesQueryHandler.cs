using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Handlers.ContractHandler;
using Contracts.Application.Handlers.CurrencyHandler.Queries.GetCurrencies;
using Contracts.Application.Handlers.FormatHandler;
using Contracts.Application.Handlers.FormatHandler.Queries.GetFormats;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.BaseHandlers;

namespace Contracts.Application.Handlers.EmployeeHandler.Queries.GetEmployees;

public class GetCurrenciesQueryHandler(
    IBaseReadRepository<Currency> currencies,
    CurrencyMemoryCache cache,
    IMapper mapper) : PaginatedQueryHandler<Currency, GetCurrenciesQuery, CurrencyDto>(currencies, mapper, cache)
{
}