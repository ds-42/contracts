using AutoMapper;
using MediatR;
using Users.Application.DTOs;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Application.Exceptions;
using Core.Auth.Application.Utils;
using Core.Users.Domain;
using Core.Users.Domain.Enums;
using Users.Application.Cashes;

namespace Users.Application.Handlers.Commands.CreateUser;

public class CreateUserCommandHandler(
    IBaseWriteRepository<User> users,
    UsersCache cache,
    IMapper mapper) : IRequestHandler<CreateUserCommand, GetUserDto>
{
    public async Task<GetUserDto> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var login = command.Login.Trim();

        if (await users.AsAsyncRead().SingleOrDefaultAsync(t => t.Login == login, cancellationToken) != null)
        {
            throw new BadRequestException("Invalid login or password");
        }

        bool admin = await users.AsAsyncRead().CountAsync(cancellationToken) == 0;

        var user = new User()
        {
            Login = login,
            Password = PasswordHashUtil.Hash(command.Password),
            Role = admin? ApplicationUserRolesEnum.Admin : ApplicationUserRolesEnum.Client,
        };

        cache.Clear();

        return mapper.Map<GetUserDto>(await users.AddAsync(user, cancellationToken));
    }
}
