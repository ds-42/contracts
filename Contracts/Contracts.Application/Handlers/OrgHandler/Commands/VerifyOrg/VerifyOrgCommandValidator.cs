using FluentValidation;

namespace Contracts.Application.Handlers.OrgHandler.Commands.VerifyOrg;

public class VerifyOrgCommandValidator : AbstractValidator<VerifyOrgCommand>
{
    public VerifyOrgCommandValidator()
    {
        RuleFor(t => t.Id)
            .NotNull()
            .GreaterThan(0);
    }
}
