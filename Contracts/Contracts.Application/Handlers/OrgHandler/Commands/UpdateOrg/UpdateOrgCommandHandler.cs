using Contracts.Application.Services;
using MediatR;

namespace Contracts.Application.Handlers.OrgHandler.Commands.UpdateOrg;

public class UpdateOrgCommandHandler(
    OrgService orgs) : IRequestHandler<UpdateOrgCommand, OrgDto>
{
    public async Task<OrgDto> Handle(UpdateOrgCommand command, CancellationToken cancellationToken)
    {
        return await orgs.UpdateOrg(command, cancellationToken);
    }
}