using Contracts.Application.Handlers.AddressHandler;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;

namespace Contracts.Application.Cashes;

public class AddressMemoryCache : BaseCache<CountableList<AddressDto>>;
