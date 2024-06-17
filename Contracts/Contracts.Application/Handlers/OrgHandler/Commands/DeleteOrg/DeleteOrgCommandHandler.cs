using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Application.Handlers.FormatTypeHandler.Commands.DeleteFormatType;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Application.Exceptions;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.OrgHandler.Commands.DeleteOrg;

public class DeleteOrgCommandHandler(
    IBaseWriteRepository<Org> orgs,
    IBaseReadRepository<OrgAdmin> admins,
    IBaseReadRepository<Contract> contracts,
    ICurrentUserService user,
    OrgMemoryCache cache) : IRequestHandler<DeleteFormatTypeCommand, bool>
{
    public async Task<bool> Handle(DeleteFormatTypeCommand command, CancellationToken cancellationToken)
    {
        await admins.TestAccess(command.Id, user.Id, cancellationToken);

        if (await contracts.UsedOrg(command.Id, cancellationToken)) 
        {
            throw new UsedAnotherTableException();
        }


        var org = await orgs.GetItem(command.Id, cancellationToken);

        await orgs.RemoveAsync(org, cancellationToken);

        cache.Clear();

        return true;
    }
}