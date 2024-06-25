using FluentValidation;

namespace Users.Application.Handlers.Commands.DeleteUser;

internal class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(t => t.UserId).NotNull();
    }
}