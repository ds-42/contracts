namespace Contracts.Application.Handlers.OwnershipHandler.Commands.CreateOwnership;

public class CreateOwnershipCommandValidator : OwnershipValidator<CreateOwnershipCommand>
{
    public CreateOwnershipCommandValidator()
    {
        RuleForName(t => t.Name);
        RuleForShortName(t => t.Name);
    }
}
