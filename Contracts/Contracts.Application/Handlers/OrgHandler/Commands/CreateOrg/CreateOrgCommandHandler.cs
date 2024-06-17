using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Application.Exceptions;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.OrgHandler.Commands.CreateOrg;

public class CreateOrgCommandHandler(
    IBaseWriteRepository<Org> orgs,
    IBaseWriteRepository<OrgAdmin> admins,
    ICurrentUserService user,
    OrgMemoryCache cache,
    IMapper mapper) : IRequestHandler<CreateOrgCommand, OrgDto>
{
    public async Task<OrgDto> Handle(CreateOrgCommand command, CancellationToken cancellationToken)
    {
        var org = await orgs.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.UNP == command.UNP, cancellationToken);

        if (org != null) 
        {
            throw new CustomException("Duplicated org");
        }

        org = command.Map();

        org = await orgs.AddAsync(org, cancellationToken);

        var admin = new OrgAdmin()
        {
            OrgId = org.Id,
            UserId = user.Id,
        };

        await admins.AddAsync(admin, cancellationToken);

        cache.Clear();

        return mapper.Map<OrgDto>(org);
    }
}