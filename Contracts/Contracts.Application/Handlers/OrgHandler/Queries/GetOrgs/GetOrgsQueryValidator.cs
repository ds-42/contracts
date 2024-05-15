using Contracts.Application.Handlers.EmployeeHandler;

namespace Contracts.Application.Handlers.OrgHandler.Queries.GetOrgs;

public class OrgsGetValidator : OrgValidator<GetOrgsQuery>
{
    public OrgsGetValidator()
    {
        RuleForPagination(t => t);
    }
}
