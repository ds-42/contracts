using Contracts.Application.Handlers.OrgHandler;
using Core.Application.Abstractions;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;

namespace Contracts.Application.Cashes;

public class PartnerCache(ICacheService cache) :
    BaseCache<CountableList<PartnerDto>>(cache);

