using Contracts.Application.Handlers.EmployeeHandler;
using Contracts.Application.Handlers.OrgHandler.Queries.GetOrgs;

namespace Contracts.Application.Handlers.PartnerHandler.Queries.GetPartners;

public class OrgsGetValidator : OrgValidator<GetOrgsQuery>
{
    public OrgsGetValidator()
    {
        RuleForPagination(t => t);
    }
}
