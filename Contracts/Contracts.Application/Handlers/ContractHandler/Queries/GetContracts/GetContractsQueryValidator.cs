using Contracts.Application.Handlers.EmployeeHandler;

namespace Contracts.Application.Handlers.ContractHandler.Queries.GetContracts;

public class GetContractsQueryValidator : ContractValidator<GetContractsQuery>
{
    public GetContractsQueryValidator()
    {
        RuleForPagination(t => t);
    }
}
