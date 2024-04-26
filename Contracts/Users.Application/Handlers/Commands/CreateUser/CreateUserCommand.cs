using MediatR;
using Users.Application.DTOs;

namespace Users.Application.Handlers.Commands.CreateUser;

public class CreateUserCommand : IRequest<GetUserDto>
{
    public required string Login { get; init; }
    public required string Password { get; init; }
}


