using Contracts.Application.Handlers.EmployeeHandler;

namespace Contracts.Application.Handlers.OrgHandler.Commands.CreateOrg;

public class CreateOrgCommandValidator : OrgValidator<CreateOrgCommand>
{
    public CreateOrgCommandValidator()
    {
        RuleForName(e => e.Name);
        RuleForShortName(e => e.Name);
        RuleForViewName(e => e.Name);
    }
}
