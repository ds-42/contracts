namespace Contracts.Application.Handlers.FormatHandler.Commands.CreateFormat;

public class CreateFormatCommandValidator : FormatValidator<CreateFormatCommand>
{
    public CreateFormatCommandValidator()
    {
        RuleForId(t => t.OrgId);
        RuleForId(t => t.FormatTypeId);
        RuleForName(t => t.Name);
    }
}
