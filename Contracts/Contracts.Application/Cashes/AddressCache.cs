using Contracts.Application.Handlers.AddressHandler;
using Core.Application.Abstractions;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;

namespace Contracts.Application.Cashes;

public class AddressCache(ICacheService cache) :
    BaseCache<CountableList<AddressDto>>(cache);
