using Contracts.Application.Extensions;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Application.Exceptions;
using Core.Auth.Application.Abstractions.Service;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Contracts.Application.Handlers.FileHandler.Commands.DeleteFile;

public class DeleteFileCommandHandler(
    IBaseWriteRepository<Domain.File> files,
    IConfiguration configuration,
    ICurrentUserService user) : IRequestHandler<DeleteFileCommand, bool>
{
    public async Task<bool> Handle(DeleteFileCommand command, CancellationToken cancellationToken)
    {
        var file = await files.GetItem(command.Id, cancellationToken);

        if (file.UserId != user.Id)
            throw new AccessDeniedException();

        var destPath = configuration["Files"];
        var path = $"{destPath}{file.Id}";

        if (File.Exists(path))
            File.Delete(path);

        await files.RemoveAsync(file, cancellationToken);

        return true;
    }
}