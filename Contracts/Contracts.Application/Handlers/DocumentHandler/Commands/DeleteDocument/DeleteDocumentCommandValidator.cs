namespace Contracts.Application.Handlers.DocumentHandler.Commands.DeleteDocument;

public class DeleteDocumentCommandValidator : DocumentValidator<DeleteDocumentCommand>
{
    public DeleteDocumentCommandValidator()
    {
        RuleForId(t => t.Id);
    }
}
