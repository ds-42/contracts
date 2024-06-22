using Core.Application.Abstractions;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;
using Users.Application.DTOs;

namespace Users.Application.Cashes;

public class UsersCache(ICacheService cache) :
    BaseCache<CountableList<GetUserDto>>(cache);
