using Contracts.Application.Cashes;
using Contracts.Application.Handlers.DocumentHandler;
using Contracts.Application.Services;
using MediatR;

namespace Contracts.Application.Handlers.ContractDocHandler.Commands.UpdateContractDoc;

public class UpdateContractDocCommandHandler(
    СontractorService contractor,
    DocumentService docs,
    ContractCache cache)
        : IRequestHandler<UpdateContractDocCommand, DocumentDto>
{
    public async Task<DocumentDto> Handle(UpdateContractDocCommand command, CancellationToken cancellationToken)
    {
        await contractor.TestAccess(cancellationToken);

        var contract = await contractor.GetContractAsync(command.ContractId, cancellationToken);

        command.Group = contract.DocumentsGroup;

        var doc = await docs.UpdateDocumentAsync(command, cancellationToken);

        cache.Clear();

        return doc;
    }
}