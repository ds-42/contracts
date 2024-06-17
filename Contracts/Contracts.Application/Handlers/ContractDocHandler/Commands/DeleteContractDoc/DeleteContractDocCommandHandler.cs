using Contracts.Application.Services;
using MediatR;

namespace Contracts.Application.Handlers.ContractDocHandler.Commands.DeleteContractDoc;

public class DeleteContractDocCommandHandler(
    СontractorService contractor,
    DocumentService docs) : IRequestHandler<DeleteContractDocCommand, bool>
{
    public async Task<bool> Handle(DeleteContractDocCommand command, CancellationToken cancellationToken)
    {
        await contractor.TestAccess(cancellationToken);

        var contract = await contractor.GetContractAsync(command.Id, cancellationToken);
        command.Group = contract.DocumentsGroup;

        return await docs.DeleteDocumentAsync(command, cancellationToken);
    }
}