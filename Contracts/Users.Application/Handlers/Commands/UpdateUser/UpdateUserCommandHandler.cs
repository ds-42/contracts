using AutoMapper;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Application.Exceptions;
using Core.Auth.Application.Abstractions.Service;
using Core.Users.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using Users.Application.Cashes;
using Users.Application.DTOs;

namespace Users.Application.Handlers.Commands.UpdateUser;

internal class UpdateUserCommandHandler(
    IBaseWriteRepository<User> users,
    IMapper mapper,
    ICurrentUserService currentUser,
    UsersCache cache,
    ILogger<UpdateUserCommandHandler> logger) : IRequestHandler<UpdateUserCommand, GetUserDto>
{

    public async Task<GetUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var userId = request.Id;

        if (currentUser.Id != userId && !currentUser.IsAdmin)
        {
            throw new ForbiddenException();
        }

        var user = await users.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.Id == userId, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException("User not found");
        }

        mapper.Map(request, user);
        user = await users.UpdateAsync(user, cancellationToken);
        var result = mapper.Map<GetUserDto>(user);

        cache.Clear();
        logger.LogWarning($"User {user.Id} updated by {currentUser.Id}");

        return result;
    }
}