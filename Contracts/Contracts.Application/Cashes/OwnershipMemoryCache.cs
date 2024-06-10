using Contracts.Application.Handlers.OwnershipHandler;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;

namespace Contracts.Application.Cashes;

public class OwnershipMemoryCache : BaseCache<CountableList<OwnershipDto>>;
