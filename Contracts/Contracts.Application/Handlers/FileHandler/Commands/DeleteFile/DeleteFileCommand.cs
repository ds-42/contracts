using MediatR;

namespace Contracts.Application.Handlers.FileHandler.Commands.DeleteFile;

public class DeleteFileCommand : IRequest<bool>
{
    public int Id { get; set; }
}


