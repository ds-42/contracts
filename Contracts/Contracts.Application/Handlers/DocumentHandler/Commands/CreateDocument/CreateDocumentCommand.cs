using Contracts.Domain;
using MediatR;

namespace Contracts.Application.Handlers.DocumentHandler.Commands.CreateDocument;

public class CreateDocumentCommand : IRequest<DocumentDto>
{
    public int GroupId { get; set; }
    public string Number { get; set; } = default!;
    public DateOnly RegistryDate { get; set; }
    public string Title { get; set; } = default!;
    public int FileId { get; set; }

    public Document Map() => new()
    {
        Id = 0,
        GroupId = GroupId,
        Number = Number,
        Title = Title,
        FileId = FileId,
    };
}


