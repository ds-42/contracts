using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Handlers.EmployeeHandler;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using FluentValidation;
using MediatR;

namespace Contracts.Application.Handlers.OrgHandler;

public class OrgAddCommand : IRequest<OrgView>
{
    public string Name { get; set; } = default!;
    public string ShortName { get; set; } = default!;
    public string ViewName { get; set; } = default!;

    public Org Map() => new Org()
    {
        Id = 0,
        Name = Name,
        ShortName = ShortName,
        ViewName = ViewName,
        OwnershipId = null,
        AddressGroup = 0,
        MailAddressId = null,
        JureAddressId = null,
        Phone = "",
        WWW = "",
        EMail = "",
        ContractsGroup = 0,
        SertificateFileId = 0,
        Verified = false,
    };
}

public class OrgAddCommandHandler(
    IBaseWriteRepository<Org> _orgs,
    IBaseWriteRepository<OrgAdmin> _admins,
    ICurrentUserService _user,
    OrgMemoryCache _cache,
    IMapper _mapper) : IRequestHandler<OrgAddCommand, OrgView>
{
    public async Task<OrgView> Handle(OrgAddCommand command, CancellationToken cancellationToken)
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

        return _mapper.Map<OrgView>(org);
    }
}

public class CreateOrgCommandValidator : OrgValidator<OrgAddCommand>
{
    public CreateOrgCommandValidator()
    {
        RuleFor(e => e.Name).NotEmpty().MaximumLength(200);
    }
}
