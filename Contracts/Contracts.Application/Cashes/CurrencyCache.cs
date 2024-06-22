using Contracts.Application.Handlers.ContractHandler;
using Core.Application.Abstractions;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;

namespace Contracts.Application.Cashes;

public class CurrencyCache(ICacheService cache) : 
    BaseCache<CountableList<CurrencyDto>>(cache);
