using MediatR;

namespace Users.Application.Handlers.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<bool>
{
    public int UserId { get; init; } = default!;
}