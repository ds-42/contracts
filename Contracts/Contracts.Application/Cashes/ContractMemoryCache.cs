using Contracts.Application.Handlers.ContractHandler;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;

namespace Contracts.Application.Cashes;

public class ContractMemoryCache : BaseCache<CountableList<ContractDto>>;

