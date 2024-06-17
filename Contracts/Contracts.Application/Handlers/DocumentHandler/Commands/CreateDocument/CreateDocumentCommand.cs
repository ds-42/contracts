using Contracts.Domain;
using MediatR;

namespace Contracts.Application.Handlers.DocumentHandler.Commands.CreateDocument;

public class CreateDocumentCommand : IRequest<DocumentDto>
{
    public int Group { get; set; }
    public string Number { get; set; } = default!;
    public DateOnly RegistryDate { get; set; }
    public string Title { get; set; } = default!;
    public int FileId { get; set; }

    public Document Map() => new()
    {
        Id = 0,
        Group = Group,
        Number = Number,
        Title = Title,
        FileId = FileId,
    };
}


