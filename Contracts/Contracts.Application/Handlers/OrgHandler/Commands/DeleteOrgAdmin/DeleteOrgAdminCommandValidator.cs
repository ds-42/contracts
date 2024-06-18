using FluentValidation;

namespace Contracts.Application.Handlers.OrgHandler.Commands.DeleteOrgAdmin;

public class DeleteOrgAdminCommandValidator : AbstractValidator<DeleteOrgAdminCommand>
{
    public DeleteOrgAdminCommandValidator()
    {
        RuleFor(t => t.UserId)
            .NotNull()
            .GreaterThan(0);
    }
}
