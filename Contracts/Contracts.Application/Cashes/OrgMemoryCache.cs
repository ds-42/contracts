using Contracts.Application.Handlers.OrgHandler;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;

namespace Contracts.Application.Cashes;

public class OrgMemoryCache : BaseCache<CountableList<OrgExDto>>;
