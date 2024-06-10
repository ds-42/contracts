using FluentValidation;

namespace Contracts.Application.Handlers.FormatTypeHandler.Commands.DeleteFormatType;

public class DeleteFormatTypeCommandValidator : AbstractValidator<DeleteFormatTypeCommand>
{
    public DeleteFormatTypeCommandValidator()
    {
        RuleFor(t => t.Id)
            .NotNull()
            .GreaterThan(0);
    }
}
