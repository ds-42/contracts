using Contracts.Application.Cashes;
using Contracts.Application.Handlers.DocumentHandler;
using Contracts.Application.Services;
using MediatR;

namespace Contracts.Application.Handlers.ContractDocHandler.Commands.CreateContractDoc;

public class CreateContractDocCommandHandler(
    СontractorService contractor,
    DocumentService docs,
    ContractMemoryCache cache) : IRequestHandler<CreateContractDocCommand, DocumentDto>
{
    public async Task<DocumentDto> Handle(CreateContractDocCommand command, CancellationToken cancellationToken)
    {
        await contractor.TestAccess(cancellationToken);

        var contract = await contractor.GetContractAsync(command.ContractId, cancellationToken);

        command.Group = contract.DocumentsGroup;

        var doc = await docs.CreateDocumentAsync(command, cancellationToken);

        if (contract.DocumentsGroup == 0)
        {
            contract.DocumentsGroup = command.Group;

            await contractor.SaveContractAsync(contract, cancellationToken);

            cache.Clear();
        }

        return doc;
    }
}