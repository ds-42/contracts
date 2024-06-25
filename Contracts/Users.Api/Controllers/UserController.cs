using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using Users.Application.Handlers.Commands.CreateUser;
using Core.Api.Controllers;
using Users.Application.Handlers.Commands.ChangePassword;
using Users.Application.Handlers.Commands.DeleteUser;
using Users.Application.Handlers.Commands.UpdateUser;

namespace Users.Api.Controllers;

[Authorize]
[ApiController]
[Route("users")]
public class UserController : BaseController
{

    public UserController(IMediator mediator) : base(mediator) 
    {
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> CreateUser(
        CreateUserCommand createUserCommand, 
        CancellationToken cancellationToken = default)
    {
        var item = await ExecCommandAsync(createUserCommand, cancellationToken);

        return Created($"users/{item.Id}", item);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(
        UpdateUserCommand command,
        CancellationToken cancellationToken = default)
    {
        var item = await ExecCommandAsync(command, cancellationToken);

        return Ok(item);
    }

    [HttpPatch("{id}/password")]
    public async Task<IActionResult> ChangePassword(int id, string password, CancellationToken cancellationToken = default)
    {
        var changePasswordCommand = new ChangePasswordCommand() 
        { 
            UserId = id, 
            Password = password 
        };

        var result = await ExecCommandAsync(changePasswordCommand, cancellationToken);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser([FromBody] int id, CancellationToken cancellationToken = default)
    {
        var deleteUserCommand = new DeleteUserCommand() { UserId = id };
        var result = await ExecCommandAsync(deleteUserCommand, cancellationToken);
        return Ok(result);
    }
}

