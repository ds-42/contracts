using Contracts.Application.Cashes;
using Contracts.Application.Handlers.DocumentHandler;
using Contracts.Application.Services;
using MediatR;


namespace Contracts.Application.Handlers.ContractDocHandler.Commands.CreateContractDoc;

public class CreateContractDocCommandHandler(
    СontractorService contractor,
    ContractMemoryCache cache) : IRequestHandler<CreateContractDocCommand, DocumentDto>
{
    public async Task<DocumentDto> Handle(CreateContractDocCommand command, CancellationToken cancellationToken)
    {
        await contractor.TestContractAccess(command.ContractId, cancellationToken);

        var contract = await contractor.GetContractAsync(command.ContractId, cancellationToken);

        command.Document.GroupId = contract.DocumentsGroup;

        var doc = await contractor.ExecCommandAsync(command.Document, cancellationToken);

        if (contract.DocumentsGroup == 0)
        {
            contract.DocumentsGroup = doc.GroupId;

            await contractor.SaveContractAsync(contract, cancellationToken);

            cache.Clear();
        }

        return doc;
    }
}