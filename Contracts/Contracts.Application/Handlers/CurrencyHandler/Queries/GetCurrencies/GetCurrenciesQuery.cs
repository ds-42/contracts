using Contracts.Application.Handlers.ContractHandler;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;
using MediatR;

namespace Contracts.Application.Handlers.CurrencyHandler.Queries.GetCurrencies;

public class GetCurrenciesQuery : BasePagination, IRequest<CountableList<CurrencyDto>>
{
}

