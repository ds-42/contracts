using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Application.Exceptions;
using Core.Auth.Application.Abstractions.Service;
using Core.Users.Domain;
using Core.Users.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Users.Application.Handlers.Commands.DeleteUser;

internal class DeleteUserCommandHandler(
    IBaseWriteRepository<User> users,
    ICurrentUserService currentUser,
    ILogger<DeleteUserCommandHandler> logger) : IRequestHandler<DeleteUserCommand, bool>
{
    public async Task<bool> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var userId = command.UserId;

        if (userId != currentUser.Id && !currentUser.IsAdmin)
        {
            throw new ForbiddenException();
        }

        var user = await users.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.Id == userId, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException("User not found");
        }

        await users.RemoveAsync(user, cancellationToken);

        logger.LogWarning($"User {user.Id} deleted by {currentUser.Id}");
        return true;
    }
}