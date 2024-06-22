using Contracts.Application.Handlers.FormatTypeHandler;
using Core.Application.Abstractions;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;

namespace Contracts.Application.Cashes;

public class FormatTypeCache(ICacheService cache) :
    BaseCache<CountableList<FormatTypeDto>>(cache);

