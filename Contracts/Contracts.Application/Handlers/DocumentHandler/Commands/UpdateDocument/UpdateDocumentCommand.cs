using Contracts.Domain;
using Core.Application.Abstractions.Mappings;
using MediatR;

namespace Contracts.Application.Handlers.DocumentHandler.Commands.UpdateDocument;

public class UpdateDocumentCommand : IMapTo<Document>, IRequest<DocumentDto>
{
    public int Id { get; set; }
    public int Group { get; set; }
    public string Number { get; set; } = default!;
    public DateOnly RegistryDate { get; set; }
    public string Title { get; set; } = default!;
}


