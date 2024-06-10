using Contracts.Application.Handlers.FormatTypeHandler;

namespace Contracts.Application.Handlers.OwnershipHandler.Commands.UpdateOwnership;

public class UpdateOwnershipCommandValidator : OwnershipValidator<UpdateOwnershipCommand>
{
    public UpdateOwnershipCommandValidator()
    {
        RuleForId(t => t.Id);
        RuleForName(t => t.Name);
        RuleForShortName(t => t.ShortName);
    }
}
