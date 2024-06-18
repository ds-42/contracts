using Contracts.Application.Handlers.OrgHandler;
using Contracts.Application.Services;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.PartnerHandler.Commands.CreatePartner;

public class CreatePartnerCommandHandler(
    СontractorService contractor,
    OrgService orgs,
    IBaseWriteRepository<Partner> partners,
    ICurrentUserService user) : IRequestHandler<CreatePartnerCommand, OrgDto>
{
    public async Task<OrgDto> Handle(CreatePartnerCommand command, CancellationToken cancellationToken)
    {
        await contractor.TestAccess(cancellationToken);

        var org = await orgs.CreateOrg(command, cancellationToken);

        var partner = await partners.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.OrgId == user.OrgId && t.PartnerId == org.Id, cancellationToken);
        if (partner == null)
        {
            partner = new Partner()
            {
                OrgId = user.OrgId,
                PartnerId = org.Id,
                ViewName = command.ViewName,
            };

            await partners.AddAsync(partner, cancellationToken);
        }

        return org;
    }
}