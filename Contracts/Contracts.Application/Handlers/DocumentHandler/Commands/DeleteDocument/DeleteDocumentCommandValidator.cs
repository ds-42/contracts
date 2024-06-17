using Contracts.Application.Handlers.FormatHandler.Commands.DeleteFormat;

namespace Contracts.Application.Handlers.DocumentHandler.Commands.DeleteDocument;

public class DeleteDocumentCommandValidator : DocumentValidator<DeleteFormatCommand>
{
    public DeleteDocumentCommandValidator()
    {
        RuleForId(t => t.Id);
    }
}
