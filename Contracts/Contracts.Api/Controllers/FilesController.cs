using Contracts.Application.Handlers.FileHandler.Commands.DeleteFile;
using Contracts.Application.Handlers.FileHandler.Commands.UploadFile;
using Core.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Contracts.Api.Controllers;

public class FilesController : AuthController
{
    public FilesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("Upload")]
    public async Task<IActionResult> Upload(
        IFormFile file,
        CancellationToken cancellationToken = default)
    {
        var command = new UploadFileCommand();
        command.File = file;

        var _file = await ExecQueryAsync(command, cancellationToken);

        return Created($"Files/{_file.Id}", _file);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFormat(
        int id,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteFileCommand() { Id = id };
        await ExecQueryAsync(command, cancellationToken);

        return Ok();
    }
}

