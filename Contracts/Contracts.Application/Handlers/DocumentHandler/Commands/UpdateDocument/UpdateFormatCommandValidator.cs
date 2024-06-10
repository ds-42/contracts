namespace Contracts.Application.Handlers.DocumentHandler.Commands.UpdateDocument;

public class UpdateDocumentCommandValidator : DocumentValidator<UpdateDocumentCommand>
{
    public UpdateDocumentCommandValidator()
    {
        RuleForId(t => t.Id);
        RuleForNumber(t => t.Number);
        RuleForTitle(t => t.Title);
    }
}
