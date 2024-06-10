using MediatR;
using Microsoft.AspNetCore.Http;

namespace Contracts.Application.Handlers.FileHandler.Commands.UploadFile;

public class UploadFileCommand : IRequest<FileDto>
{
    public IFormFile File { get; set; } = default!;
    public Domain.File Map() => new()
    {
        Id = 0,
        UserId = 0,
        FileName = File.FileName,
        Date = DateTime.UtcNow,
    };
}


