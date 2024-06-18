using Contracts.Application.Extensions;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.OrgHandler.Commands.AppendOrgAdmin;

public class AppendOrgAdminCommandHandler(
    IBaseWriteRepository<OrgAdmin> admins,
    ICurrentUserService user) : IRequestHandler<AppendOrgAdminCommand, bool>
{
    public async Task<bool> Handle(AppendOrgAdminCommand command, CancellationToken cancellationToken)
    {
        await admins.TestAccess(user.OrgId, user.Id, cancellationToken);

        var exists = await admins.AsAsyncRead()
            .AnyAsync(t => t.OrgId == user.OrgId && t.UserId == command.UserId, cancellationToken);

        if (!exists)
        {
            var admin = new OrgAdmin()
            {
                OrgId = user.OrgId,
                UserId = command.UserId,
            };

            await admins.AddAsync(admin, cancellationToken);
        }

        return true;
    }
}