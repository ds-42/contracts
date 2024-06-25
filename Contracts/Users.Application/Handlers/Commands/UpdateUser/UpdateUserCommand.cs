using Core.Application.Abstractions.Mappings;
using Core.Users.Domain;
using MediatR;
using Users.Application.DTOs;

namespace Users.Application.Handlers.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<GetUserDto>, IMapTo<User>
{
    public int Id { get; init; }

    public string Login { get; init; } = default!;
}