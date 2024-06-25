using MediatR;

namespace Users.Application.Handlers.Commands.ChangePassword;

public class ChangePasswordCommand : IRequest<bool>
{
    public int UserId { get; init; }

    public string Password { get; init; } = default!;
}