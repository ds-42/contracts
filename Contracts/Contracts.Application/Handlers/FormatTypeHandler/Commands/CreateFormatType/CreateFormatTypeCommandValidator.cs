namespace Contracts.Application.Handlers.FormatTypeHandler.Commands.CreateFormatType;

public class CreateFormatTypeCommandValidator : FormatTypeValidator<CreateFormatTypeCommand>
{
    public CreateFormatTypeCommandValidator()
    {
        RuleForName(t => t.Name);
    }
}
