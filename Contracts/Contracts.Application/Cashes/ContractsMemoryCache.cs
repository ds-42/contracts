using Core.Application.BaseRealizations;
using Contracts.Application.DTOs;
using Core.Application.DTOs;

namespace Contracts.Application.Cashes;

public class ContractsMemoryCache : BaseCache<CountableList<GetContractDto>>;
