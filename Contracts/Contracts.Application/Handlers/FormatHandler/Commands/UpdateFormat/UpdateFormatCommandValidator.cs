namespace Contracts.Application.Handlers.FormatHandler.Commands.UpdateFormat;

public class UpdateFormatCommandValidator : FormatValidator<UpdateFormatCommand>
{
    public UpdateFormatCommandValidator()
    {
        RuleForId(t => t.Id);
        RuleForId(t => t.FormatTypeId);
        RuleForName(t => t.Name);
    }
}
