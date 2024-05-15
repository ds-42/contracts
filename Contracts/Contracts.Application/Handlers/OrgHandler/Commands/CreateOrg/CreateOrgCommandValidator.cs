using Contracts.Application.Handlers.EmployeeHandler;
using FluentValidation;

namespace Contracts.Application.Handlers.OrgHandler.Commands.CreateOrg;

public class CreateOrgCommandValidator : OrgValidator<CreateOrgCommand>
{
    public CreateOrgCommandValidator()
    {
        RuleFor(e => e.Name).NotEmpty().MaximumLength(200);
    }
}
