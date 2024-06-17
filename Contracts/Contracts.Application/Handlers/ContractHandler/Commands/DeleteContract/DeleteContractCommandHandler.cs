using Contracts.Application.Cashes;
using Contracts.Application.Services;
using MediatR;

namespace Contracts.Application.Handlers.ContractHandler.Commands.DeleteContract;

public class DeleteContractCommandHandler(
    СontractorService contractor,
    FormatMemoryCache cache) : IRequestHandler<DeleteContractCommand, bool>
{
    public async Task<bool> Handle(DeleteContractCommand command, CancellationToken cancellationToken)
    {
        await contractor.TestAccess(cancellationToken);

        var contract = await contractor.GetContractAsync(command.Id, cancellationToken);

        await contractor.RemoveContractAsync(contract, cancellationToken);

        cache.Clear();

        return true;
    }
}