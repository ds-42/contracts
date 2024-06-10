using FluentValidation;

namespace Contracts.Application.Handlers.FileHandler.Commands.UploadFile;

public class UploadFileCommandValidator : AbstractValidator<UploadFileCommand>
{
    public UploadFileCommandValidator()
    {
        RuleFor(t => t.File)
            .NotNull();
    }
}
