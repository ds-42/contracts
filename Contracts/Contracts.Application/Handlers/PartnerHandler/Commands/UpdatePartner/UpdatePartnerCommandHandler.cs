using Contracts.Application.Handlers.OrgHandler;
using Contracts.Application.Handlers.OrgHandler.Commands.UpdateOrg;
using Contracts.Application.Services;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.PartnerHandler.Commands.UpdatePartner;

public class UpdatePartnerCommandHandler(
    OrgService orgs,
    IBaseWriteRepository<Partner> partners, 
    ICurrentUserService user) : IRequestHandler<UpdateOrgCommand, OrgDto>
{
    public async Task<OrgDto> Handle(UpdateOrgCommand command, CancellationToken cancellationToken)
    {
        var partner = await partners.AsAsyncRead()
            .SingleAsync(t => t.OrgId == user.OrgId && t.PartnerId == command.Id, cancellationToken);
        partner.ViewName = command.ViewName;
        await partners.UpdateAsync(partner, cancellationToken);

        if (await orgs.HaveAdmins(command.Id, cancellationToken)) 
        {
            return await orgs.UpdateOrg(command, cancellationToken);
        }

        return await orgs.GetOrg(command.Id, cancellationToken);
    }
}