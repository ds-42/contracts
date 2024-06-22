using Contracts.Application.Handlers.EmployeeHandler;
using Core.Application.Abstractions;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;

namespace Contracts.Application.Cashes;

public class EmployeeCache(ICacheService cache) :
    BaseCache<CountableList<EmployeeDto>>(cache);
