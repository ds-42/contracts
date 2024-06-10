using AutoMapper;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Contracts.Application.Handlers.FileHandler.Commands.UploadFile;

public class UploadFileCommandHandler(
    IBaseWriteRepository<Domain.File> files,
    IConfiguration configuration,
    ICurrentUserService user,
    IMapper _mapper) : IRequestHandler<UploadFileCommand, FileDto>
{
    public async Task<FileDto> Handle(UploadFileCommand command, CancellationToken cancellationToken)
    {
        var item = command.Map();
        item.UserId = user.Id;

        var file = await files.AddAsync(item, cancellationToken);

        var destPath = configuration["Files"];
        using (var fileStream = new FileStream($"{destPath}{file.Id}", FileMode.Create))
        {
            await command.File.CopyToAsync(fileStream);
        }
        return _mapper.Map<FileDto>(file);
    }
}