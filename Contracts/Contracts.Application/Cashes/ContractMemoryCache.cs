using Core.Application.BaseRealizations;
using Core.Application.DTOs;
using Contracts.Application.Handlers.EmployeeHandler;
using Contracts.Application.Handlers.OrgHandler;
using Contracts.Application.Handlers.ContractHandler;

namespace Contracts.Application.Cashes;

public class ContractMemoryCache : BaseCache<CountableList<ContractView>>;
public class EmployeeMemoryCache : BaseCache<CountableList<EmployeeView>>;
public class OrgMemoryCache : BaseCache<CountableList<OrgView>>;
