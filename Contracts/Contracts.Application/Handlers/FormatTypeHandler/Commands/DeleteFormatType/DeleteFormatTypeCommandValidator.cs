using Contracts.Application.Handlers.FormatHandler;
using Contracts.Application.Handlers.FormatHandler.Commands.DeleteFormat;

namespace Contracts.Application.Handlers.FormatTypeHandler.Commands.DeleteFormatType;

public class DeleteFormatCommandValidator : FormatValidator<DeleteFormatCommand>
{
    public DeleteFormatCommandValidator()
    {
        RuleForId(t => t.Id);
    }
}
