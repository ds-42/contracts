using Contracts.Application.Handlers.OrgHandler.Commands.DeleteOrg;
using Contracts.Application.Handlers.OrgHandler.Commands.VerifyOrg;
using FluentValidation;

namespace Contracts.Application.Handlers.PartnerHandler.Commands.DeletePartner;

public class DeleteOrgCommandValidator : AbstractValidator<DeleteOrgCommand>
{
    public DeleteOrgCommandValidator()
    {
        RuleFor(t => t.Id)
            .NotNull()
            .GreaterThan(0);
    }
}
