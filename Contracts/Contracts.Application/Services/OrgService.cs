using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Application.Handlers.OrgHandler;
using Contracts.Application.Handlers.OrgHandler.Commands.CreateOrg;
using Contracts.Application.Handlers.OrgHandler.Commands.UpdateOrg;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Threading;

namespace Contracts.Application.Services;

public class OrgService(
    IBaseWriteRepository<Org> orgs,
    ICurrentUserService user,
    IBaseWriteRepository<OrgAdmin> admins,
    IBaseReadRepository<Address> addresses,
    OrgMemoryCache cache,
    IMapper mapper)
{
    public async Task<OrgDto> GetOrg(int orgId, CancellationToken cancellationToken)
    {
        var org = await orgs.GetItem(orgId, cancellationToken);
        return mapper.Map<OrgDto>(org);
    }

    public async Task<OrgDto> CreateOrg(CreateOrgCommand command, CancellationToken cancellationToken)
    {
        var org = await orgs.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.UNP == command.UNP, cancellationToken);

        if (org != null)
        {
            return mapper.Map<OrgDto>(org);
        }

        org = command.Map();

        org = await orgs.AddAsync(org, cancellationToken);

        cache.Clear();

        return mapper.Map<OrgDto>(org);
    }

    protected async Task ValidateAddress(int group, int? addressId, CancellationToken cancellationToken)
    {
        if (addressId != null)
        {
            await addresses.TestExists(group, addressId.Value, cancellationToken);
        }
    }

    public async Task<OrgDto> UpdateOrg(UpdateOrgCommand command, CancellationToken cancellationToken)
    {
        await admins.TestAccess(command.Id, user.Id, cancellationToken);

        var org = await orgs.GetItem(command.Id, cancellationToken);

        await ValidateAddress(org.AddressGroup, command.JureAddressId, cancellationToken);
        await ValidateAddress(org.AddressGroup, command.MailAddressId, cancellationToken);

        mapper.Map(command, org);

        await orgs.UpdateAsync(org, cancellationToken);

        cache.Clear();
        return mapper.Map<OrgDto>(org);
    }

    public async Task<bool> HaveAdmins(int orgId, CancellationToken cancellationToken) 
    {
        return await admins.AsAsyncRead()
            .AnyAsync(t => t.OrgId == orgId, cancellationToken);
    }

}
