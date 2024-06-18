using FluentValidation;

namespace Contracts.Application.Handlers.OrgHandler.Commands.AppendOrgAdmin;

public class AppendOrgAdminCommandValidator : AbstractValidator<AppendOrgAdminCommand>
{
    public AppendOrgAdminCommandValidator()
    {
        RuleFor(t => t.UserId)
            .NotNull()
            .GreaterThan(0);
    }
}
