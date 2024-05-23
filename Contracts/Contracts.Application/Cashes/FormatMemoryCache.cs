using Contracts.Application.Handlers.ContractHandler;
using Contracts.Application.Handlers.FormatHandler;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;

namespace Contracts.Application.Cashes;

public class FormatMemoryCache : BaseCache<CountableList<FormatDto>>;
