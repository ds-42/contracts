using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Application.Handlers.FormatTypeHandler.Commands.DeleteFormatType;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Application.Exceptions;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.OwnershipHandler.Commands.DeleteOwnership;

public class DeleteOwnershipCommandHandler(
    IBaseWriteRepository<Ownership> ownerships,
    IBaseWriteRepository<Org> orgs,
    ICurrentUserService user,
    OwnershipMemoryCache cache) : IRequestHandler<DeleteOwnershipCommand, bool>
{
    public async Task<bool> Handle(DeleteOwnershipCommand command, CancellationToken cancellationToken)
    {
        user.TestAccess();

        //if (await orgs.UsedOwnership(command.Id, cancellationToken))
        //    throw new UsedAnotherTableException();

        var ownership = await ownerships.GetItem(command.Id, cancellationToken);

        await ownerships.RemoveAsync(ownership, cancellationToken);

        cache.Clear();

        return true;
    }
}