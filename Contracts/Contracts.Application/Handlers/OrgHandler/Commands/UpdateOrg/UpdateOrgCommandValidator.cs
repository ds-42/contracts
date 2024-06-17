using Contracts.Application.Handlers.EmployeeHandler;

namespace Contracts.Application.Handlers.OrgHandler.Commands.UpdateOrg;

public class UpdateOrgCommandValidator : OrgValidator<UpdateOrgCommand>
{
    public UpdateOrgCommandValidator()
    {
        RuleForId(t => t.Id);
        RuleForName(e => e.Name);
        RuleForShortName(e => e.Name);
        RuleForViewName(e => e.Name);
    }
}
