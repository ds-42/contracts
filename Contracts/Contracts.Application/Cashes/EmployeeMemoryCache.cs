using Contracts.Application.Handlers.EmployeeHandler;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;

namespace Contracts.Application.Cashes;

public class EmployeeMemoryCache : BaseCache<CountableList<EmployeeDto>>;
