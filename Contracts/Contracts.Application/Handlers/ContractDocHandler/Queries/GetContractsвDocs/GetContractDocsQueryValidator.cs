using Contracts.Application.Handlers.EmployeeHandler;

namespace Contracts.Application.Handlers.ContractDocHandler.Queries.GetContractsвDocs;

public class GetContractDocsQueryValidator : ContractValidator<GetContractDocsQuery>
{
    public GetContractDocsQueryValidator()
    {
        RuleForPagination(t => t);
        RuleForId(t => t.ContractId);
    }
}
