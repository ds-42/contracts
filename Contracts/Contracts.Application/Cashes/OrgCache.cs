using Contracts.Application.Handlers.OrgHandler;
using Core.Application.Abstractions;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;

namespace Contracts.Application.Cashes;

public class OrgCache(ICacheService cache) :
    BaseCache<CountableList<OrgExDto>>(cache);

