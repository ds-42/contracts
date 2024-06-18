using Contracts.Application.Handlers.EmployeeHandler;

namespace Contracts.Application.Handlers.OrgHandler.Queries.GetOrgs;

public class GetOrgsValidator : OrgValidator<GetOrgsQuery>
{
    public GetOrgsValidator()
    {
        RuleForPagination(t => t);
    }
}
