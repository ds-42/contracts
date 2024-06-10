namespace Contracts.Application.Handlers.FormatTypeHandler.Commands.UpdateFormatType;

public class UpdateFormatTypeCommandValidator : FormatTypeValidator<UpdateFormatTypeCommand>
{
    public UpdateFormatTypeCommandValidator()
    {
        RuleForId(t => t.Id);
        RuleForName(t => t.Name);
    }
}
