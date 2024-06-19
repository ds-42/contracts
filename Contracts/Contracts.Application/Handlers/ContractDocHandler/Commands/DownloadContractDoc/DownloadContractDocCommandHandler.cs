using Contracts.Application.Services;
using MediatR;

namespace Contracts.Application.Handlers.ContractDocHandler.Commands.DownloadContractDoc;

public class DownloadContractDocCommandHandler(
    СontractorService contractor,
    DocumentService docs) : IRequestHandler<DownloadContractDocCommand, DocumentInfo>
{
    public async Task<DocumentInfo> Handle(DownloadContractDocCommand command, CancellationToken cancellationToken)
    {
        await contractor.TestAccess(cancellationToken);

        var doc = await docs.GetDocumentAsync(command.Id, cancellationToken);

        // валидация договора
        await contractor.GetContractByDocGroupAsync(doc.Group, cancellationToken);

        return await docs.GetInfoAsync(doc, cancellationToken);
    }
}