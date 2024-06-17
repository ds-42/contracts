using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.OrgHandler.Commands.UpdateOrg;

public class UpdateOrgCommandHandler(
    IBaseWriteRepository<Org> orgs,
    IBaseReadRepository<Address> addresses,
    IBaseReadRepository<OrgAdmin> admins,
    ICurrentUserService user,
    OrgMemoryCache cache,
    IMapper mapper) : IRequestHandler<UpdateOrgCommand, OrgDto>
{
    public async Task<OrgDto> Handle(UpdateOrgCommand command, CancellationToken cancellationToken)
    {
        await admins.TestAccess(command.Id, user.Id, cancellationToken);

        var org = await orgs.GetItem(command.Id, cancellationToken);

        if (command.JureAddressId != null) 
        {
            await addresses.TestExists(org.AddressGroup, command.JureAddressId.Value, cancellationToken);
        }

        if (command.MailAddressId != null)
        {
            await addresses.TestExists(org.AddressGroup, command.MailAddressId.Value, cancellationToken);
        }

        mapper.Map(command, org);

        await orgs.UpdateAsync(org, cancellationToken);

        cache.Clear();

        return mapper.Map<OrgDto>(org);
    }
}