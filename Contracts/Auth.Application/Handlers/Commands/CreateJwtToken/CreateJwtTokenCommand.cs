using Auth.Application.DTOs;
using MediatR;

namespace Auth.Application.Handlers.Commands.CreateJwtToken;

public class CreateJwtTokenCommand : IRequest<JwtTokenDto>
{
    public string Login { get; init; } = default!;

    public string Password { get; init; } = default!;

    public int? OrgId { get; init; }
}