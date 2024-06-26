﻿using Contracts.Application.Handlers.ContractHandler;
using Contracts.Application.Handlers.FormatHandler;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;
using MediatR;

namespace Contracts.Application.Handlers.CurrencyHandler.Queries.GetCurrencies;

public class GetCurrenciesQuery : BasePagination, IRequest<CountableList<CurrencyDto>>
{
}

