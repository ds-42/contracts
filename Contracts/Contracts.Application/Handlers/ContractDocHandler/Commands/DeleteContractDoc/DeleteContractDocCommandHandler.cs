using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Application.Services;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using MediatR;

namespace Contracts.Application.Handlers.ContractDocHandler.Commands.DeleteContractDoc;

public class DeleteDocumentCommandHandler(
    СontractorService contractor,
    IBaseWriteRepository<Contract> contracts,
    IBaseWriteRepository<Document> documents,
    DocumentMemoryCache cache) : IRequestHandler<DeleteContractDocCommand, bool>
{
    public async Task<bool> Handle(DeleteContractDocCommand command, CancellationToken cancellationToken)
    {
        var doc = await documents.GetItem(0, command.Id, cancellationToken);

        var contract = await contracts.AsAsyncRead()
            .SingleAsync(t => t.DocumentsGroup == doc.GroupId, cancellationToken);

        await contractor.TestAccess(contract.Id, cancellationToken);

        await documents.RemoveAsync(doc, cancellationToken);

        cache.Clear();

        return true;
    }
}