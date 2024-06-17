﻿using Contracts.Domain;
using MediatR;

namespace Contracts.Application.Handlers.OrgHandler.Commands.CreateOrg;

public class CreateOrgCommand : IRequest<OrgDto>
{
    public string Name { get; set; } = default!;
    public string ShortName { get; set; } = default!;
    public string ViewName { get; set; } = default!;
    public int? OwnershipId { get; set; }

    public Org Map() => new()
    {
        Id = 0,
        Name = Name,
        ShortName = ShortName,
        ViewName = ViewName,
        OwnershipId = OwnershipId,
        AddressGroup = 0,
        MailAddressId = null,
        JureAddressId = null,
        Phone = "",
        WWW = "",
        EMail = "",
        SertificateFileId = 0,
        Verified = false,
    };
}

