using Contracts.Application.Services;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.OrgHandler.Commands.CreateOrg;

public class CreateOrgCommandHandler(
    OrgService orgs,
    IBaseWriteRepository<OrgAdmin> admins,
    ICurrentUserService user) : IRequestHandler<CreateOrgCommand, OrgDto>
{
    public async Task<OrgDto> Handle(CreateOrgCommand command, CancellationToken cancellationToken)
    {
        var org = await orgs.CreateOrg(command, cancellationToken);

        var existsAdmin = await admins.AsAsyncRead()
            .AnyAsync(t => t.OrgId == org.Id, cancellationToken);

        if (existsAdmin == false)
        {
            var admin = new OrgAdmin()
            {
                OrgId = org.Id,
                UserId = user.Id,
            };

            await admins.AddAsync(admin, cancellationToken);
        }

        return org;
    }
}