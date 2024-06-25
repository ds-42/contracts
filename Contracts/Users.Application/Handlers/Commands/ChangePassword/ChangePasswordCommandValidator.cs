using FluentValidation;
using Users.Application.Handlers.Commands.ChangePassword;

namespace Users.Application.Handlers.Commands.UpdateUserPassword;

internal class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
        RuleFor(e => e.Password).MinimumLength(5).MaximumLength(100).NotEmpty();
    }
}