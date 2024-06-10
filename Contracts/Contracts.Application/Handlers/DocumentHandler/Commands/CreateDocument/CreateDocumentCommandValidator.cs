namespace Contracts.Application.Handlers.DocumentHandler.Commands.CreateDocument;

public class CreateDocumentCommandValidator : DocumentValidator<CreateDocumentCommand>
{
    public CreateDocumentCommandValidator()
    {
        RuleForId(t => t.FileId);
        RuleForTitle(t => t.Title);
    }
}
