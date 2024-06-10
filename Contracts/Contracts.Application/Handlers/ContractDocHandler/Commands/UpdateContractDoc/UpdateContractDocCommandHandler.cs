using Contracts.Application.Handlers.DocumentHandler;
using Contracts.Application.Services;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using MediatR;

namespace Contracts.Application.Handlers.ContractDocHandler.Commands.UpdateContractDoc;

public class UpdateContractDocCommandHandler(
    СontractorService contractor)
        : IRequestHandler<UpdateContractDocCommand, DocumentDto>
{
    public async Task<DocumentDto> Handle(UpdateContractDocCommand command, CancellationToken cancellationToken)
    {
        await contractor.TestContractAccess(command.ContractId, cancellationToken);

        command.Document.Group = await contractor.GetContractDocumentGroupAsync(command.ContractId, cancellationToken);

        return await contractor.ExecCommandAsync(command.Document, cancellationToken);
    }
}