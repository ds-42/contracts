using Contracts.Application.Handlers.FormatHandler;
using Contracts.Application.Handlers.FormatHandler.Commands.UpdateFormat;

namespace Contracts.Application.Handlers.FormatTypeHandler.Commands.UpdateFormatType;

public class UpdateFormatCommandValidator : FormatValidator<UpdateFormatCommand>
{
    public UpdateFormatCommandValidator()
    {
        RuleForId(t => t.Id);
        RuleForId(t => t.FormatTypeId);
        RuleForName(t => t.Name);
    }
}
