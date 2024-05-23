using Contracts.Application.Handlers.FormatTypeHandler;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;

namespace Contracts.Application.Cashes;

public class FormatTypeMemoryCache : BaseCache<CountableList<FormatTypeDto>>;
