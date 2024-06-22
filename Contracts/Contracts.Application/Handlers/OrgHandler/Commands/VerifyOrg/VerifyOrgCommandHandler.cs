using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.OrgHandler.Commands.VerifyOrg;

public class VerifyOrgCommandHandler(
    IBaseWriteRepository<Org> orgs,
    ICurrentUserService user,
    OrgCache cache) : IRequestHandler<VerifyOrgCommand, bool>
{
    public async Task<bool> Handle(VerifyOrgCommand command, CancellationToken cancellationToken)
    {
        user.TestAccess();

        var org = await orgs.GetItem(command.Id, cancellationToken);

        org.Verified = command.State;

        await orgs.UpdateAsync(org, cancellationToken);

        cache.Clear();

        return true;
    }
}