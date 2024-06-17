using FluentValidation;

namespace Contracts.Application.Handlers.OrgHandler.Commands.DeleteOrg;

public class DeleteOrgCommandValidator : AbstractValidator<DeleteOrgCommand>
{
    public DeleteOrgCommandValidator()
    {
        RuleFor(t => t.Id)
            .NotNull()
            .GreaterThan(0);
    }
}
