using Contracts.Application.Handlers.ContractHandler;
using Core.Application.Abstractions;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;

namespace Contracts.Application.Cashes;

public class ContractCache(ICacheService cache) :
    BaseCache<CountableList<ContractExDto>>(cache);

