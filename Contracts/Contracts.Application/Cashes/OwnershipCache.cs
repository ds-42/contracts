using Contracts.Application.Handlers.OwnershipHandler;
using Core.Application.Abstractions;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;

namespace Contracts.Application.Cashes;

public class OwnershipCache(ICacheService cache) :
    BaseCache<CountableList<OwnershipDto>>(cache);


