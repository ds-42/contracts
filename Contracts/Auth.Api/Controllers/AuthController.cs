using Auth.Application.Handlers.Commands.CreateJwtToken;
using Auth.Application.Handlers.Commands.CreateJwtTokenByRefreshToken;
using Core.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : BaseController
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("CreateJwtToken")]
    public async Task<IActionResult> CreateJwtToken(CreateJwtTokenCommand command, CancellationToken cancellationToken)
    {
        var token = await ExecCommandAsync(command, cancellationToken);

        return Ok(token);
    }

    [HttpPost("CreateJwtTokenByRefreshToken")]
    public async Task<IActionResult> CreateJwtTokenByRefreshToken(string refreshToken, CancellationToken cancellationToken)
    {
        var command = new CreateJwtTokenByRefreshTokenCommand() { RefreshToken = refreshToken };

        var token = await ExecCommandAsync(command, cancellationToken);

        return Ok(token);
    }

}
