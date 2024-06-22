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
    IBaseWriteRepository<User> _users,
    UsersCache _cache,
    IMapper _mapper) : IRequestHandler<CreateUserCommand, GetUserDto>
{
    public async Task<GetUserDto> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var login = command.Login.Trim();

        if (await _users.AsAsyncRead().SingleOrDefaultAsync(t => t.Login == login, cancellationToken) != null)
        {
            throw new BadRequestException("Invalid login or password");
        }

        bool admin = await _users.AsAsyncRead().CountAsync(cancellationToken) == 0;

        var user = new User()
        {
            Login = login,
            Password = PasswordHashUtil.Hash(command.Password),
            Role = admin? ApplicationUserRolesEnum.Admin : ApplicationUserRolesEnum.Client,
        };

        _cache.Clear();

        return _mapper.Map<GetUserDto>(await _users.AddAsync(user, cancellationToken));
    }
}
