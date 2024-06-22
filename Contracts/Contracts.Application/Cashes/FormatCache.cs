using Contracts.Application.Handlers.FormatHandler;
using Core.Application.Abstractions;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;

namespace Contracts.Application.Cashes;

public class FormatCache(ICacheService cache) :
    BaseCache<CountableList<FormatExDto>>(cache);

