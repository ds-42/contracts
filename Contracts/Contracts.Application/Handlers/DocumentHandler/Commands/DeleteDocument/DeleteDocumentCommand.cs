using MediatR;

namespace Contracts.Application.Handlers.DocumentHandler.Commands.DeleteDocument;

public class DeleteDocumentCommand : IRequest<bool>
{
    public int Id { get; set; }
    public int Group { get; set; }
}


