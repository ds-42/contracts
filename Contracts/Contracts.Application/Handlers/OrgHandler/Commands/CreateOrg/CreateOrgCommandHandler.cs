using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.OrgHandler.Commands.CreateOrg;

public class CreateOrgCommandHandler(
    IBaseWriteRepository<Org> _orgs,
    IBaseWriteRepository<OrgAdmin> _admins,
    ICurrentUserService _user,
    OrgMemoryCache _cache,
    IMapper _mapper) : IRequestHandler<CreateOrgCommand, OrgDto>
{
    public async Task<OrgDto> Handle(CreateOrgCommand command, CancellationToken cancellationToken)
    {
        var org = command.Map();

        org = await _orgs.AddAsync(org, cancellationToken);

        var admin = new OrgAdmin()
        {
            OrgId = org.Id,
            UserId = _user.Id,
        };

        await _admins.AddAsync(admin, cancellationToken);

        _cache.Clear();

        return _mapper.Map<OrgDto>(org);
    }
}