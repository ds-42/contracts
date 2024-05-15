using Contracts.Application.Handlers.ContractHandler.Commands.ContractAdd;
using Contracts.Application.Handlers.EmployeeHandler;

namespace Contracts.Application.Handlers.ContractHandler.Queries.GetContracts;

public class GetContractsQueryValidator : ContractValidator<GetContractsQuery>
{
    public GetContractsQueryValidator()
    {
        RuleForPagination(t => t);
        RuleForId(t => t.OrgId);
    }
}
