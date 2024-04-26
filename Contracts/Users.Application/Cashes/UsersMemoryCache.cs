using Core.Application.BaseRealizations;
using Core.Application.DTOs;
using Users.Application.DTOs;

namespace Users.Application.Cashes;

public class UsersMemoryCache : BaseCache<CountableList<GetUserDto>>;
