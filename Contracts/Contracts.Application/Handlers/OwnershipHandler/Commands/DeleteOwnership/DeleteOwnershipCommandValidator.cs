using FluentValidation;

namespace Contracts.Application.Handlers.OwnershipHandler.Commands.DeleteOwnership;

public class DeleteOwnershipCommandValidator : AbstractValidator<DeleteOwnershipCommand>
{
    public DeleteOwnershipCommandValidator()
    {
        RuleFor(t => t.Id)
            .NotNull()
            .GreaterThan(0);
    }
}
