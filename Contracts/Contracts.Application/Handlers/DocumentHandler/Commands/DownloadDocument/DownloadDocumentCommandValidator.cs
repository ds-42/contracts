namespace Contracts.Application.Handlers.DocumentHandler.Commands.DownloadDocument;

public class DownloadDocumentCommandValidator : DocumentValidator<DownloadDocumentCommand>
{
    public DownloadDocumentCommandValidator()
    {
        RuleForId(t => t.Id);
    }
}
