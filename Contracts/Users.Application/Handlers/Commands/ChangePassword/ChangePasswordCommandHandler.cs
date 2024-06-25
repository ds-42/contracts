using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Application.Exceptions;
using Core.Auth.Application.Abstractions.Service;
using Core.Auth.Application.Utils;
using Core.Users.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Users.Application.Handlers.Commands.ChangePassword;

internal class ChangePasswordCommandHandler(
    IBaseWriteRepository<User> users,
    ICurrentUserService currentUser,
    ILogger<ChangePasswordCommandHandler> logger) : IRequestHandler<ChangePasswordCommand, bool>
{
    public async Task<bool> Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
    {
        var userId = command.UserId;
        var user = await users.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.Id == userId, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException("User not found");
        }

        if (currentUser.Id != userId && !currentUser.IsAdmin)
        {
            throw new ForbiddenException();
        }

        user.Password = PasswordHashUtil.Hash(command.Password);
        await users.UpdateAsync(user, cancellationToken);

        logger.LogWarning($"User password for {user.Id} updated by {currentUser.Id}");

        return true;
    }
}